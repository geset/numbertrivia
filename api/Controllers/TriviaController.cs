using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using api.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriviaController : Controller //ControllerBase
    {
        [HttpGet("{number}")]
        public  async Task<TriviaResponse> getAsyc(int number){
            //call numberapi.com and return results
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://numbersapi.com/" + number + "?json");
            var triviaResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TriviaResponse>(triviaResult);
        }

        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
