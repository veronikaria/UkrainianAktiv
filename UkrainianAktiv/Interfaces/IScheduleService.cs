using UkrainianAktiv.ViewModels;

namespace UkrainianAktiv.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<ScheduleItemDto> GetCurrent();
        Task<IEnumerable<ScheduleItemDto>> GetCurrentAsync();
        IEnumerable<ScheduleItemDto> GetForPeriod(DateTime startDate, DateTime endDate);
        Task<IEnumerable<ScheduleItemDto>> GetForPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
