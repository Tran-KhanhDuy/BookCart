using BookCart.Data;
using BookCart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookCart.Areas.FE.Controllers
{
    [Area("FE")]
    public class HomeController : Controller
    {
        BookcartDbContext _ctx;

        public HomeController(BookcartDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IActionResult> Index()
        {
            List<Book> featured =await _ctx.Books.Where( b => b.Features != null && b.Features.Value).Take(0).ToListAsync();
            ViewBag.Featured = featured;
            List<Book> bestselling = await _ctx.Books.Take(0).ToListAsync();
            List<Book> latest = await _ctx.Books.Take(0).ToListAsync();
            ViewBag.Bestselling = bestselling;
            ViewBag.Latest = latest;
            return View();
        }
    }
}
