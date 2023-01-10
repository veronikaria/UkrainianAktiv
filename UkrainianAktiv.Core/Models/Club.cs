using UkrainianAktiv.Core.Constant;
using UkrainianAktiv.Core.Interfaces;

namespace UkrainianAktiv.Core.Models
{
    public class Club : BaseItem, IActionProvider, IPurchaseable
    {
        public string Subtitle { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ImageUrl { get; set; }
        public string IconClass { get; set; }
        public int Price { get; set; }
        public ClubType Type { get; set; }
    }
}
