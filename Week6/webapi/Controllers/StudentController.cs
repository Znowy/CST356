using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Database;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<StudentController>> Get()
        {
            return Ok(getStudents());
        }

        private List<Student> getStudents()
        {
            return InMemory.Students;
        }
    }
}