using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Repositories;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchRepository _rep;

        public SearchController(SearchRepository rep)
        {
            _rep = rep;
        }

        [HttpGet("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            return Ok(_rep.GetAllCourse());
        }

        [HttpGet("GetAllGroups")]
        public IActionResult GetAllGroups()
        {
            return Ok(_rep.GetAllGroup());
        }

        [HttpGet("GetAllLessons")]
        public IActionResult GetAllLessons()
        {
            return Ok(_rep.GetAllLessons());
        }
    }
}
