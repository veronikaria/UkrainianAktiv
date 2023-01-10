using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UkrainianAktiv.Core.Models;
using UkrainianAktiv.Interfaces;
using UkrainianAktiv.ViewModels;

namespace UkrainianAktiv.Services
{
    public class ScheduleService : BaseService<ScheduleItem, ScheduleItemDto>, IScheduleService
    {
        public ScheduleService(IMapper mapper, DataContext context) : base(mapper, context)
        {
        }

        public IEnumerable<ScheduleItemDto> GetCurrent()
        {
            return GetForPeriod(DateTime.Today, DateTime.Today.AddMonths(1));
        }

        public async Task<IEnumerable<ScheduleItemDto>> GetCurrentAsync()
        {
            return await GetForPeriodAsync(DateTime.Today, DateTime.Today.AddMonths(1));
        }

        public IEnumerable<ScheduleItemDto> GetForPeriod(DateTime startDate, DateTime endDate)
        {
            var schedule = Context.Schedule.Where(s => s.Date >= startDate && s.Date <= endDate);
            return MapToViewModel(schedule);
        }

        public async Task<IEnumerable<ScheduleItemDto>> GetForPeriodAsync(DateTime startDate, DateTime endDate)
        {
            var schedule = await Context.Schedule.Where(s => s.Date >= startDate && s.Date <= endDate).ToListAsync();
            return MapToViewModel(schedule);
        }
    }
}
