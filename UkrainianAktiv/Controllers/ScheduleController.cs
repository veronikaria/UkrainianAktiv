using Microsoft.AspNetCore.Mvc;
using UkrainianAktiv.Interfaces;

namespace UkrainianAktiv.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [Route("schedule")]
        public async Task<IActionResult> GetSchedule()
        {
            var schedule = await _scheduleService.GetCurrentAsync();
            return View("ScheduleList", schedule.OrderBy(s => s.Date));
        }
    }
}
