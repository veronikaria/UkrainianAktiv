using UkrainianAktiv.Core.Interfaces;


namespace UkrainianAktiv.Core.Models
{
    public class Event : BaseItem, IPurchaseable
    {
        public string Subtitle { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int Price { get; set; }
    }
}
