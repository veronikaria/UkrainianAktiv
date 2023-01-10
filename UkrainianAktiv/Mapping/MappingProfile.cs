using AutoMapper;
using UkrainianAktiv.Core.Models;
using UkrainianAktiv.ViewModels;

namespace UkrainianAktiv.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Club, ClubDto>();
            CreateMap<Course, CourseDto>();
            CreateMap<ScheduleItem, ScheduleItemDto>();
        }
    }
}
