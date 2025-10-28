using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marcu_Alexandru_Lab2.Data;
using Marcu_Alexandru_Lab2.Models;
using Marcu_Alexandru_Lab2.Models.ViewModels;

namespace Marcu_Alexandru_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Marcu_Alexandru_Lab2Context _context;

        public IndexModel(Marcu_Alexandru_Lab2Context context)
        {
            _context = context;
        }

        public CategoryIndexData CategoryData { get; set; }

        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCat)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CatName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var category = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .Single();
                CategoryData.Books = category.BookCat
                    .Select(bc => bc.Book);
            }
        }
    }
}
