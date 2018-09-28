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
    [Route("api/Course")]
    public class CourseController : Controller
    {
        private ISchoolDataStore _dataStore;
        public CourseController(ISchoolDataStore dataStore)
        {
            _dataStore = dataStore;
        }
        // GET: api/Course
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataStore.GetCourses());
            
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Course course = _dataStore.GetCourseById(id);
            if (course == null)
                return NotFound();
            else 
                return Ok(course);
        }
        
        // POST: api/Course
        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            _dataStore.AddCourse(course);
            return Ok(course);
        }
        
        // PUT: api/Course/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Course course)
        {
            if (id != course.CourseId)
                return BadRequest();
            else
            {
                Course updatedCourse = _dataStore.UpdataCourse(id, course);
                if (updatedCourse != null)
                    return Accepted(updatedCourse);
                else
                    return NotFound();
            }
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
