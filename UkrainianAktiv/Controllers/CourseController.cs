using Microsoft.AspNetCore.Mvc;
using UkrainianAktiv.Interfaces;
using UkrainianAktiv.Services;

namespace UkrainianAktiv.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService; 
        }

        [Route("courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetCoursesAsync();
            return View("CourseList", courses);
        }
    }
}
