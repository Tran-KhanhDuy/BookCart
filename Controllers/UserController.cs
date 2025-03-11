using BookCart.Data;
using BookCart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        async Task PopulateRoles()
        {
            var roles = await _ctx.Roles.ToListAsync();
            ViewBag.Roles = roles;
        }

        public async Task<IActionResult> Create()
        {
            var roles = await _ctx.Roles.ToListAsync();
            SelectList rolelist = new SelectList(roles, "Id", "Name");
            ViewBag.Roles = rolelist;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _ctx.Users.AddAsync(user);
                await _ctx.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [Route("(id)")]
        public async Task<IActionResult> Edit(int id)
        {
            await PopulateRoles();
            var user = await _ctx.Users.SingleOrDefaultAsync(u => u.Id == id);
            return View(user);
        }
    }
}

