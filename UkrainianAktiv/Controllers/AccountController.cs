using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UkrainianAktiv.Core.Models;
using UkrainianAktiv.ViewModels;

namespace UkrainianAktiv.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountDto account)
        {
            if (ModelState.IsValid)
            {
                var status = await _signInManager.PasswordSignInAsync(account.UserName, account.Password, false, false);
                if (status == Microsoft.AspNetCore.Identity.SignInResult.Success)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

                ModelState.AddModelError(string.Empty, "Невірне ім'я користувача або пароль");
            }

            return View(account);
        }
    }
}
