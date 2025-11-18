namespace Marcu_Alexandru_Lab2.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CatName { get; set; }
        public ICollection<BookCat>? BookCat { get; set; }

    }
}
