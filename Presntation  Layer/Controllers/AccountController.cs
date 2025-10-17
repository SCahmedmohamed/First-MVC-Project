using Microsoft.AspNetCore.Mvc;

namespace Presntation__Layer.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
