using Microsoft.EntityFrameworkCore;
using Marcu_Alexandru_Lab2.Models;

namespace Marcu_Alexandru_Lab2.Data
{
    public class Marcu_Alexandru_Lab2Context : DbContext
    {
        public Marcu_Alexandru_Lab2Context(DbContextOptions<Marcu_Alexandru_Lab2Context> options)
            : base(options) { }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;   
        public DbSet<Marcu_Alexandru_Lab2.Models.BookCat> BookCat { get; set; } = default!;
        public DbSet<Marcu_Alexandru_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Marcu_Alexandru_Lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<Marcu_Alexandru_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;
    }
}
