using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marcu_Alexandru_Lab2.Data;
using Marcu_Alexandru_Lab2.Models;

namespace Marcu_Alexandru_Lab2.Pages
{
    public class EditModel : PageModel
    {
        private readonly Marcu_Alexandru_Lab2.Data.Marcu_Alexandru_Lab2Context _context;

        public EditModel(Marcu_Alexandru_Lab2.Data.Marcu_Alexandru_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public BookCat BookCat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookcat =  await _context.BookCat.FirstOrDefaultAsync(m => m.ID == id);
            if (bookcat == null)
            {
                return NotFound();
            }
            BookCat = bookcat;
           ViewData["BookID"] = new SelectList(_context.Book, "ID", "ID");
           ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookCat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookCatExists(BookCat.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookCatExists(int id)
        {
            return _context.BookCat.Any(e => e.ID == id);
        }
    }
}
