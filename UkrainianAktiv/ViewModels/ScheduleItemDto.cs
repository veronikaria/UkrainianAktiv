namespace UkrainianAktiv.ViewModels
{
    public class ScheduleItemDto : EventDto
    {
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Teacher { get; set; }
    }
}
