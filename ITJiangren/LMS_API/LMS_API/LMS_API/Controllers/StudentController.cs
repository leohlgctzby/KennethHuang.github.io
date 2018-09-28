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
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private ISchoolDataStore _dataStore;

        public StudentController(ISchoolDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        // GET: api/Student
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataStore.GetAllStudents());
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _dataStore.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
        
        // POST: api/Student
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            _dataStore.AddStudent(student);
            return Ok(student);
        }
        
        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Student student)
        {
            Student updatedStudent = _dataStore.UpdateStudent(id, student);
            if (updatedStudent != null)
                return Accepted(updatedStudent);
            else
                return NotFound();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_dataStore.DelStudent(id))
            {
                return NoContent();
            }
            else
                return NotFound();
        }
    }
}
