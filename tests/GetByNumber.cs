using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using api.Dto;

namespace tests
{
    public class GetByNumber : ApiControllerTestBase
    {
        private readonly HttpClient _client;

        public GetByNumber()
        {
            _client = base.GetClient();
        }

        [Theory]
        [InlineData("trivia")]
        public async Task ReturnsTextForTheNumber42(string controllerName)
        {
            var response = await _client.GetAsync($"/api/{controllerName}/42");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TriviaResponse>(stringResponse);

            Assert.Equal(42, result.Number);
            Assert.NotEmpty(result.Text);
            //just testing like hell
        }
    }
}
