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
        }
    }
}
