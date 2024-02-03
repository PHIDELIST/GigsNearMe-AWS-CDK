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
            });
        }
    }
}
