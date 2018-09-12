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
    [Route("api/TriangleType")]
    public class TriangleTypeController : Controller
    {

        // GET api/TriangleType
        [HttpGet]
        //public IEnumerable<string> Get()
        public string Get()
        {
            // return new string[] { "value1", "value2" };
            return "Please input 3# in the address bar, inform of api/length1/length2/length3.";
        }

        // GET api/TriangleType/5/5/6
        [HttpGet("{l1}/{l2}/{l3}")]
        public IActionResult Get(float l1,float l2, float l3)
        {
            return Ok(MyMath.TriangleType(l1,l2,l3));
        }

        // POST api/TriangleType
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/TriangleType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/TriangleType/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}