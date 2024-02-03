using Amazon.CDK;
using Amazon.CDK.AWS.EC2;
using Constructs;

namespace GigsNearMeInfra
{
    public class GigsNearMeInfraStack : Stack
    {
        internal GigsNearMeInfraStack(Amazon.CDK.Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // The code that defines your stack goes here
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
            var scalingGroup = new AutoScalingGroup(this, "ASG", new AutoScalingGroupProps
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
        }
    }
}
