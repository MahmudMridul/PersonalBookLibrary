namespace LibraryAPI.Models
{
    /* One book can have many authors
     * One author can write many books
     */
    public class BooksAuthors
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}
