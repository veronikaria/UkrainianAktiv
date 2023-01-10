using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UkrainianAktiv.Core.Models;
using UkrainianAktiv.Interfaces;
using UkrainianAktiv.ViewModels;

namespace UkrainianAktiv.Services
{
    public class CourseService : BaseService<Course, CourseDto>, ICourseService
    {
        public CourseService(IMapper mapper, DataContext context) : base(mapper, context) {}

        public IEnumerable<CourseDto> GetCourses()
        {
            var courses = Context.Courses.Where(c => c.Enabled);
            return MapToViewModel(courses);
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesAsync()
        {
            var courses = await Context.Courses.Where(c => c.Enabled).ToListAsync();
            return MapToViewModel(courses);
        }
    }
}
