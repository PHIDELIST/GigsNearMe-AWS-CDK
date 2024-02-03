using Amazon.CDK;
using Amazon.CDK.AWS.EC2;
using Amazon.CDK.AWS.S3;
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
            //S3 bucket to store artifacts
            var artifactsBucket = new Bucket(this, "ArtifactsBucket", new BucketProps
            {
                Versioned = true,
                RemovalPolicy = RemovalPolicy.DESTROY,
                AutoDeleteObjects = true
            });

            new CfnOutput(this, "ArtifactsBucketName", new CfnOutputProps
            {
                Value = artifactsBucket.BucketName
            });
            //Cloud Trail 
            var trail = new Trail(this, "GigsNearMeTrail", new TrailProps
            {
                Bucket = new Bucket(this, "TrailLogsBucket", new BucketProps
                {
                    RemovalPolicy = RemovalPolicy.DESTROY,
                    AutoDeleteObjects = true
                })
            });

            trail.AddS3EventSelector(
                new[]
                {
            new S3EventSelector
            {
                Bucket = artifactsBucket
            }
                    },
                    new AddEventSelectorOptions
                    {
                        ReadWriteType = ReadWriteType.WRITE_ONLY
                    }
                );
            
            //AWS CODE PIPLELINE TO DEPLOY THE APP
            var codeDeployApp = new ServerApplication(this, "GigsNearMe", new ServerApplicationProps
                {
                    ApplicationName = "GigsNearMe"
                });
            var deploymentGroup = new ServerDeploymentGroup(this, "WebHostDG", new ServerDeploymentGroupProps
            {
                Application = codeDeployApp,
                AutoScalingGroups = new AutoScalingGroup[] { scalingGroup },
                DeploymentGroupName = "DeploymentGroup",
                InstallAgent = false, // we did this already as part of EC2 instance intitialization userdata
                Role = new Role(this, "DeploymentRole", new RoleProps
                {
                    AssumedBy = new ServicePrincipal("codedeploy.amazonaws.com"),
                    ManagedPolicies = new IManagedPolicy[]
                    {
                        ManagedPolicy.FromAwsManagedPolicyName("service-role/AWSCodeDeployRole")
                    }
                }),
                DeploymentConfig = ServerDeploymentConfig.ONE_AT_A_TIME
            });

            const string DeploymentArtifactName = "GigsNearMeDeploymentBundle.zip";

            new CfnOutput(this, "DeploymentArtifactName", new CfnOutputProps {
                Value = DeploymentArtifactName
            });

            var deploymentArtifact = new Artifact_("DeploymentArtifact");

            var pipeline = new Pipeline(this, "CiCdPipeline", new PipelineProps
            {
                ArtifactBucket = artifactsBucket,
                Stages = new [] {
                    new Amazon.CDK.AWS.CodePipeline.StageProps {
                        StageName = "Download",
                        Actions = new [] {
                            new S3SourceAction(new S3SourceActionProps {
                                ActionName = "DownloadBundle",
                                RunOrder = 1,
                                Bucket = artifactsBucket,
                                BucketKey = DeploymentArtifactName,
                                Trigger = S3Trigger.EVENTS,
                                Output = deploymentArtifact
                            })
                        }
                    },
                    new Amazon.CDK.AWS.CodePipeline.StageProps {
                        StageName = "Deploy",
                        Actions = new [] {
                            new CodeDeployServerDeployAction(new CodeDeployServerDeployActionProps {
                                ActionName = "DeployViaCodeDeploy",
                                RunOrder = 2,
                                DeploymentGroup = deploymentGroup,
                                Input = deploymentArtifact
                            })
                        }
                    }
                }
            });
    }
}
}
