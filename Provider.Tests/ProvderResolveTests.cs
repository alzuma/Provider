using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Provider.WebApi.Tests;
using Shouldly;
using Xunit;

namespace Provider.Tests
{
    public class ProvderResolveTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ProvderResolveTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ValuesGet()
        {
            var response = await _client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var resultList = JsonConvert.DeserializeObject<List<string>>(responseString);

            resultList.Count.ShouldBe(2);
            resultList.ShouldContain("value1");
            resultList.ShouldContain("value2");
        }

        [Fact]
        public async Task ValuesGetAdmin()
        {
            var response = await _client.GetAsync("/api/values/admin");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var resultList = JsonConvert.DeserializeObject<List<string>>(responseString);

            resultList.Count.ShouldBe(3);
            resultList.ShouldContain("value1");
            resultList.ShouldContain("value2");
            resultList.ShouldContain("value3");
        }
    }
}
