using System;
using System.Collections.Generic;
using System.Linq;
using Marcu_Alexandru_Lab2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Marcu_Alexandru_Lab2.Data;

namespace Marcu_Alexandru_Lab2.Models
{
    public class BookCatPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Marcu_Alexandru_Lab2Context context, Book book)
        {
            var allCategories = context.Category;
   
            var bookCategories = new HashSet<int>(book.BookCat?.Select(c => c.CategoryID) ?? Enumerable.Empty<int>());
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CatName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateBookCategories(Marcu_Alexandru_Lab2Context context, string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.BookCat = new List<BookCat>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            // Guard against bookToUpdate.BookCat being null
            var bookCategories = new HashSet<int>(bookToUpdate.BookCat?.Select(c => c.CategoryID) ?? Enumerable.Empty<int>());

            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        // Ensure collection is initialized before adding
                        if (bookToUpdate.BookCat == null)
                        {
                            bookToUpdate.BookCat = new List<BookCat>();
                        }

                        bookToUpdate.BookCat.Add(new BookCat
                        {
                            BookID = bookToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        var bookToRemove = bookToUpdate.BookCat?.SingleOrDefault(i => i.CategoryID == cat.ID);
                        if (bookToRemove != null)
                        {
                            context.Remove(bookToRemove);
                        }
                    }
                }
            }
        }
    }
}
