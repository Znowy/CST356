using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Database;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<InstructorController>> Get()
        {
            return Ok(getInstructors());
        }

        private List<Instructor> getInstructors()
        {
            return InMemory.Instructors;
        }
    }
}