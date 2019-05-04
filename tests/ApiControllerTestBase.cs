using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.IO;

namespace tests
{
    public class ApiControllerTestBase
    {
        protected HttpClient GetClient()
        {
            var builder = new WebHostBuilder()
              .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>()
                .UseEnvironment("Testing");

            var server = new TestServer(builder);
            var client = server.CreateClient();

            //client always expects json results
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;

        }

    }
}
