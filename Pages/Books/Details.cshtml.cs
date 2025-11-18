using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marcu_Alexandru_Lab2.Models;

namespace Marcu_Alexandru_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Marcu_Alexandru_Lab2.Data.Marcu_Alexandru_Lab2Context _context;
        public DetailsModel(Marcu_Alexandru_Lab2.Data.Marcu_Alexandru_Lab2Context context) { _context = context; }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCat)
                    .ThenInclude(bc => bc.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null) return NotFound();
            return Page();
        }
    }
}
