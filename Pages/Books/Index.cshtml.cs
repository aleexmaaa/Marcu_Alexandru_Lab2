using Marcu_Alexandru_Lab2.Models;
using Marcu_Alexandru_Lab2.Data; // Add this using directive if Marcu_Alexandru_Lab2Context is defined in the Data namespace
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc; // Add this using directive for BindProperty


namespace Marcu_Alexandru_Lab2.Pages.Books
{
    public class IndexModel(Marcu_Alexandru_Lab2Context context) : PageModel
    {
        private readonly Marcu_Alexandru_Lab2Context _context = context;

        public IList<Book> Book { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .ToListAsync();
        }
    }
}
