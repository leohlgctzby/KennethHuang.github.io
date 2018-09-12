using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MathAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ReverWords")]
    public class ReverWordsController : Controller
    {
        // GET api/ReverWords
        [HttpGet]
        //public IEnumerable<string> Get()
        public string Get()
        {
            // return new string[] { "value1", "value2" };
            return "Please input a sentence in the address bar.";
        }

        // GET api/ReverWords/5
        [HttpGet("{words}")]
        public IActionResult Get(string words)
        {
            return Ok(MyMath.ReverseWords(words));
        }

        // POST api/ReverWords
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/ReverWords/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/ReverWords/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}