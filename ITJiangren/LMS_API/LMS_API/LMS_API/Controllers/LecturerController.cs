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
    [Route("api/Lecturer")]
    public class LecturerController : Controller
    {
        private SchoolDataStore _dataStore;
        public LecturerController(SchoolDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        // GET: api/Lecturer
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataStore.GetAllLecturers());
        }

        // GET: api/Lecturer/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var lecturer = _dataStore.GetLecturerById(id);
            if (lecturer != null)
                return Ok(lecturer);
            else
                return NotFound();
        }
        
        // POST: api/Lecturer
        [HttpPost]
        public IActionResult Post([FromBody]Lecturer lecturer)
        {
            _dataStore.AddLectuer(lecturer);
            return Ok(lecturer);
        }
        
        // PUT: api/Lecturer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Lecturer lecturer)
        {
            var tempLecturer= _dataStore.updateLecturer(id, lecturer);
            if (tempLecturer != null)
                return Ok(tempLecturer);
            else
                return NotFound();

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_dataStore.DelCourse(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}
