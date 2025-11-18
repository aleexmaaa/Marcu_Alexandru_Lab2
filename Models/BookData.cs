namespace Marcu_Alexandru_Lab2.Models
{
    public class BookData
    {

        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<BookCat> BookCat { get; set; }

    }
}
