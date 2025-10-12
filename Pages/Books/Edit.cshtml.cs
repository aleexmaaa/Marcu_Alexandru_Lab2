using Marcu_Alexandru_Lab2.Models;
using Marcu_Alexandru_Lab2.Data; // Add this using directive if Marcu_Alexandru_Lab2Context is defined in the Data namespace
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc; // Add this using directive for BindProperty

namespace Marcu_Alexandru_Lab2.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly Marcu_Alexandru_Lab2Context _context;
        public EditModel(Marcu_Alexandru_Lab2Context context) => _context = context;

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)   // <- adăugat
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null) return NotFound();

            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName", Book?.PublisherID);
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "LastName", Book?.AuthorID);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName", Book.PublisherID);
                ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "LastName", Book.AuthorID);
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
