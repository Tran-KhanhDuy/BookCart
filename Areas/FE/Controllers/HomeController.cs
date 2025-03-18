using Microsoft.AspNetCore.Mvc;

namespace BookCart.Areas.FE.Controllers
{
    public class HomeController : Controller
    {
        [Area("FE")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
