using WireMock.Server;
using System.Linq;
using WireMock.Logging;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Settings;
using BillingApiTask.Models;

namespace BillingApiTask.Tests
{
    public class ServerMock
    {
        public ServerMock()
        {
            if (this.Server != null)
                return;

            this.Settings = new WireMockServerSettings()
            {
                StartAdminInterface = true,
            };

            this.Server = WireMockServer.Start(this.Settings);
        }

        public ServerMock(IWireMockLogger logger)
        {
            if (this.Server != null)
                return;

            this.Settings = new WireMockServerSettings()
            {
                StartAdminInterface = true,
            };

            this.Server = WireMockServer.Start(this.Settings);
        }

        public int Port => this.Server.Ports.First();

        public WireMockServerSettings Settings { get; set; }

        public WireMockServer Server { get; internal set; }

        public void Reset()
        {
            this.Server.ResetMappings();
            this.Server.ResetScenarios();
            this.Server.ResetLogEntries();
        }

        public void Run()
        {
            this.Reset();
        }

        public void Stop()
        {
            this.Server.Stop();
        }

        public void MockSuccesfullClientResponse(string number)
        {
            this.Server
                .Given(Request.Create()
                    .WithPath(new WildcardMatcher("/post"))
                    .UsingPost()
                    .WithBody(new JsonPartialMatcher($"{{ \"Number\": \"{number}\" }}"))
                )
                .RespondWith(Response.Create()
                    .WithStatusCode(200)
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBodyAsJson(new PaymentGatewayResult { Success = true })
                );
        }
    }
}
