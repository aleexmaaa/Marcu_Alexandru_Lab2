using Marcu_Alexandru_Lab2.Pages.Publishers;

namespace Marcu_Alexandru_Lab2.Models
{
    public class BookCat
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
