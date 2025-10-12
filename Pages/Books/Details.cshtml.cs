using Marcu_Alexandru_Lab2.Models;
using Marcu_Alexandru_Lab2.Data; // Add this using directive if Marcu_Alexandru_Lab2Context is defined in the Data namespace
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc; // Add this using directive for BindProperty

namespace Marcu_Alexandru_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Marcu_Alexandru_Lab2Context _context;
        public DetailsModel(Marcu_Alexandru_Lab2Context context) => _context = context;

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)   
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book == null) return NotFound();
            Book = book;
            return Page();
        }
    }
}
