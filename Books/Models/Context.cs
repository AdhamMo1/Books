using Microsoft.EntityFrameworkCore;

namespace Books.Models
{
    public class Context : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public Context() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-0O3M1AH\\SQLEXPRESS;Database=Books;Integrated Security=True;Integrated Security=SSPI;Trusted_Connection=Yes");
        }
    }
}
