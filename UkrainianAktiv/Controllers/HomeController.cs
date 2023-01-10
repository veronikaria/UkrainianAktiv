using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UkrainianAktiv.Interfaces;
using UkrainianAktiv.Models;
using UkrainianAktiv.Services;

namespace UkrainianAktiv.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly ClubService _service;

        public HomeController(ILogger<HomeController> logger, ClubService service)
        {
            _logger = logger;
            _service = service;
        }

        [Route("")]
        [Route("home")]
        public IActionResult Index()
        {
            var clubs = _service.GetAll();
            return View(clubs);
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("contacts")]
        public IActionResult Contacts()
        {
            return View();
        }

        [Route("error/{code?}")]
        public IActionResult Error(string code)
        {
            return code == "404" ? View("404") : View();
        }

        
    }
}