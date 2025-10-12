using Marcu_Alexandru_Lab2.Models;
using Marcu_Alexandru_Lab2.Data; // Add this using directive if Marcu_Alexandru_Lab2Context is defined in the Data namespace
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc; // Add this using directive for BindProperty



namespace Marcu_Alexandru_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Marcu_Alexandru_Lab2Context _context;
        public CreateModel(Marcu_Alexandru_Lab2Context context) => _context = context;

        [BindProperty]
        public Book Book { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName", Book?.PublisherID);
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "LastName", Book?.AuthorID);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
                ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "LastName");
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
