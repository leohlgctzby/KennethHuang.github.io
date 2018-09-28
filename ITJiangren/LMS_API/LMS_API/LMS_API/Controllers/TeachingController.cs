using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS_API.Model;

namespace LMS_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Teaching")]
    public class TeachingController : Controller
    {
        SchoolDataStore _dataStore;
        public TeachingController(SchoolDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        // GET: api/Teaching
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return _dataStore.GetTeaching
        //}

        // GET: api/Teaching/5
        [HttpGet("{lecturerId}/{courseId}")]
        public IActionResult Get(int lecturerId, int courseId)
        {
            return Ok(_dataStore.GetTeaching(lecturerId, courseId));
        }
        
        // POST: api/Teaching
        [HttpPost]
        public void Post([FromBody]TeachingIdPair teachingIdPair)
        {
            _dataStore.AddTeaching(teachingIdPair.lecturerId, teachingIdPair.courseId);

        }

        //// PUT: api/Teaching/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete()]
        public IActionResult Delete([FromBody]TeachingIdPair teachingIdPair)
        {
            if (_dataStore.DelTeaching(teachingIdPair.lecturerId, teachingIdPair.courseId))
                return NoContent();
            else
                return NotFound();
              
        }
    }
}
