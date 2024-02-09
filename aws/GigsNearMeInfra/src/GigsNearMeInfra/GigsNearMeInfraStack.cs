using Amazon.CDK;
using Amazon.CDK.AWS.
using Amazon.CDK.AWS.IAM;
using Amazon.CDK.AWS.SSM
using Constructs;

namespace GigsNearMeInfra
{
    public class GigsNearMeInfraStack : Stack
    {
        internal GigsNearMeInfraStack(Amazon.CDK.Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // The code that defines your stack goes here
            //VPC
            var vpc = new Vpc(this, "GigsNearMeVpc", new VpcProps
            {
                Cidr = "10.0.0.0/16",
                MaxAzs = 2,
                SubnetConfiguration = new SubnetConfiguration[]
                    {
                        new SubnetConfiguration
                        {
                            CidrMask = 24,
                            SubnetType = SubnetType.PUBLIC,
                            Name = "GigsNearMePublic"
                        },
                        new SubnetConfiguration
                        {
                            CidrMask = 24,
                            SubnetType = SubnetType.PRIVATE_ISOLATED,
                            Name = "GigsNearMePrivate"
                        }
                    }
            });

            var loadBalancer = new ApplicationLoadBalancer(this, "LB", new ApplicationLoadBalancerProps
            {
                Vpc = vpc,
                InternetFacing = true
            });

            var lbListener = loadBalancer.AddListener("HttpListener", new BaseApplicationListenerProps
            {
                Port = 80,
                Protocol = ApplicationProtocol.HTTP
            });
            lbListener.Connections.AllowDefaultPortFromAnyIpv4("Public access to port 80");

            lbListener.AddTargets("ASGTargets", new AddApplicationTargetsProps
            {
                Port = 5000, // the port the Kestrel-hosted app will be exposed on
                Protocol = ApplicationProtocol.HTTP,
                Targets = new[] { scalingGroup }
            });

            scalingGroup.ScaleOnRequestCount("DemoLoad", new RequestCountScalingProps
            {
                TargetRequestsPerMinute = 10 // enough for demo purposes
            });
            new CfnOutput(this, "AppUrl", new CfnOutputProps
            {
                Value = $"http://{loadBalancer.LoadBalancerDnsName}"
            var appRole = new Role(this, "InstanceRole", new RoleProps
            {
                AssumedBy = new ServicePrincipal("ec2.amazonaws.com"),
                            ManagedPolicies = new IManagedPolicy[]
                {
                    ManagedPolicy.FromAwsManagedPolicyName("AmazonSSMManagedInstanceCore"),
                    ManagedPolicy.FromAwsManagedPolicyName("service-role/AWSCodeDeployRole")
                }
            });

            appRole.AddToPolicy(new PolicyStatement(new PolicyStatementProps
            {
                Effect = Effect.ALLOW,
                Actions = new string[] { "ssm:GetParametersByPath" },
                Resources = new string[]
                {
            Arn.Format(new ArnComponents
            {
                Service = "ssm",
                Resource = "parameter",
                ResourceName = "gigsnearme/*"
            }, this)
                    }
                }));

                db.Secret.GrantRead(appRole);
            }
            new StringParameter(this, "GigsNearMeDbSecretsParameter", new StringParameterProps
            {
                ParameterName = "gigsnearme/dbsecretsname",
                StringValue = db.Secret.SecretName
                });

            //RDS DB
            const int dbPort = 1433;
            var db = new DatabaseInstance(this, "DB", new DatabaseInstanceProps

            {
                Vpc = vpc,
                VpcSubnets = new SubnetSelection
                {
                    SubnetType = SubnetType.PRIVATE_ISOLATED
                },

                MachineImage = MachineImage.LatestAmazonLinux(new AmazonLinuxImageProps
                {
                    Generation = AmazonLinuxGeneration.AMAZON_LINUX_2
                }),
                InstanceType = InstanceType.Of(InstanceClass.BURSTABLE3, InstanceSize.MICRO),
                MinCapacity = 1,
                MaxCapacity = 2,
                AllowAllOutbound = true,
                Role = appRole,
                Signals = Signals.WaitForCount(1, new SignalsOptions
                {
                    Timeout = Duration.Minutes(10)
                }),
            });
            var scalingGroup = new AutoScalingGroup(this, "ASG", new AutoScalingGroupProps)
            scalingGroup.AddUserData(new string[]
            {
                "yum -y update",
                "rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm",
                "yum -y install dotnet-runtime-5.0",
                "yum -y install aspnetcore-runtime-5.0",
                "yum -y install ruby",
                "yum -y install wget",
                "cd /tmp",
                $"wget https://aws-codedeploy-{props.Env.Region}.s3.{props.Env.Region}.amazonaws.com/latest/install",
                "chmod +x ./install",
                "./install auto",
                "service codedeploy-agent start",
            });

            scalingGroup.AddUserData(new string[]
            {
                "curl https://aws-tc-largeobjects.s3-us-west-2.amazonaws.com/Curation/DotNet/CDK/deploySampleApp.sh | bash"
            });

            scalingGroup.UserData.AddSignalOnExitCommand(scalingGroup);

                Engine = DatabaseInstanceEngine.SqlServerEx(new SqlServerExInstanceEngineProps
                {
                    Version = SqlServerEngineVersion.VER_14
                }),
                InstanceType = InstanceType.Of(InstanceClass.BURSTABLE2, InstanceSize.MICRO),
                Port = dbPort,
                InstanceIdentifier = "gigsnearmedb",
                BackupRetention = Duration.Seconds(0)

            });
        }
    }
}
