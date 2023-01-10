using Microsoft.AspNetCore.Mvc;
using UkrainianAktiv.Services;
using UkrainianAktiv.ViewModels;

namespace UkrainianAktiv.ViewComponents
{
    [ViewComponent(Name = "ClubTiles")]
    public class ClubTiles : ViewComponent
    {
        private readonly ClubService _service;

        public ClubTiles(ClubService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clubs = await GetClubsAsync();
            return View(clubs);
        }

        private Task<IEnumerable<ClubDto>> GetClubsAsync()
        {
            return _service.GetAllAsync();
        }
    }
}
