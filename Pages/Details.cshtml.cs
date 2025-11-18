using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marcu_Alexandru_Lab2.Data;
using Marcu_Alexandru_Lab2.Models;

namespace Marcu_Alexandru_Lab2.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Marcu_Alexandru_Lab2.Data.Marcu_Alexandru_Lab2Context _context;

        public DetailsModel(Marcu_Alexandru_Lab2.Data.Marcu_Alexandru_Lab2Context context)
        {
            _context = context;
        }

        public BookCat BookCat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookcat = await _context.BookCat.FirstOrDefaultAsync(m => m.ID == id);
            if (bookcat == null)
            {
                return NotFound();
            }
            else
            {
                BookCat = bookcat;
            }
            return Page();
        }
    }
}
