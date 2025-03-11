using BookCart.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookCart.Controllers
{
    public class UserController : Controller
    {
        readonly BookcartDbContext _ctx;

        public UserController(BookcartDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _ctx.Users.ToListAsync();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
