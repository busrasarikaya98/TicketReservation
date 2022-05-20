using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AdminsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
