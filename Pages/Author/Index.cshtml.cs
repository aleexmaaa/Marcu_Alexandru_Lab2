using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marcu_Alexandru_Lab2.Data;
using Marcu_Alexandru_Lab2.Models;

namespace Marcu_Alexandru_Lab2.Pages.Author
{
    public class IndexModel : PageModel
    {
        private readonly Marcu_Alexandru_Lab2.Data.Marcu_Alexandru_Lab2Context _context;

        public IndexModel(Marcu_Alexandru_Lab2.Data.Marcu_Alexandru_Lab2Context context)
        {
            _context = context;
        }

        public IList<Marcu_Alexandru_Lab2.Models.Author> Author { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}
