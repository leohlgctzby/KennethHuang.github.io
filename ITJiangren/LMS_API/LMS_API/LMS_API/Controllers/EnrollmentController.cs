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
    [Route("api/Enrollment")]
    public class EnrollmentController : Controller
    {
        private ISchoolDataStore _dataStore;

        public EnrollmentController(ISchoolDataStore dataStore)
        {
            _dataStore = dataStore;
        }
        
        //// GET: api/Enrollment
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Enrollment/5
        [HttpGet("{idStudent}/{idCourse}")]
        public IActionResult Get(int idStudent, int idCourse)
        {
            return Ok(_dataStore.GetEnrollment(idStudent, idStudent));
        }
        
        // POST: api/Enrollment
        [HttpPost]
        public void Post([FromBody] EnrollmentIdPair enrollmentIdPair)
        {
            _dataStore.AddEnrollment(enrollmentIdPair.studentId, enrollmentIdPair.courseId);
        }
        
        //// PUT: api/Enrollment/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete()]
        public void Delete([FromBody] EnrollmentIdPair enrollmentIdPair)
        {
            _dataStore.DelEnrollment(enrollmentIdPair.studentId, enrollmentIdPair.courseId);
        }
    }
}
