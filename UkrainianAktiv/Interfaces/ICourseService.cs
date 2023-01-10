using UkrainianAktiv.ViewModels;

namespace UkrainianAktiv.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<CourseDto> GetCourses();
        Task<IEnumerable<CourseDto>> GetCoursesAsync();
    }
}
