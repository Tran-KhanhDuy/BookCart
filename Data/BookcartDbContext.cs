using BookCart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BookCart.Data
{
    public class BookcartDbContext : DbContext
    {
        public BookcartDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartsDetail { get; set; }
    }
}
