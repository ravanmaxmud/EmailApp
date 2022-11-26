using Microsoft.AspNetCore.Mvc;

namespace EmailApp.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
