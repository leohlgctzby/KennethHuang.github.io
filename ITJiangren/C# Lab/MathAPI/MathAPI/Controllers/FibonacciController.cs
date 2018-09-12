using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MathAPI.Model;

namespace MathAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Fibonacci")]
    public class FibonacciController : Controller
    {

        //// GET api/Fibonacci
        //[HttpGet]
        ////public IEnumerable<string> Get()
        //public string Get()
        //{
        //    return "Please input number in the address bar.";
        //    //return "<html><body><form action="+"' / Fibonacci /' "+">n:<br><input type="+"'text'"+" name="+"'id'"+" value="+"'1'"+"><input type="+"'submit'"+" value="+"'Submit'"+"></form></body></html>";
        //    // return new string[] { "value1", "value2" };
        //    //return MyMath.Fibonacci(1);
        //}

        // GET api/Fibonacci/5
        //[HttpGet("{n}")]

        //Get api/Fibonacci?n=5
        [HttpGet]
        public IActionResult Get(int n)
        {
            long result = MyMath.Fibonacci(n);
            if (result != -1)
                return Ok(result);
            else
                return Ok("no content");
        }

        [HttpGet("api/Fibonacci")]
        public async Task<IActionResult> GetNumber(
    [FromQuery]int n)
        {
            long result = MyMath.Fibonacci(n);
            if (result != -1)
                return Ok(result);
            else
                return Ok("no content");
        }

        // POST api/Fibonacci
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Fibonacci/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Fibonacci/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}