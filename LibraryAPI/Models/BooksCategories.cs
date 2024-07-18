namespace LibraryAPI.Models
{
    /* One book can have multiple categories
     * One category can belong to multiple books
     */
    public class BooksCategories
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }
    }
}
