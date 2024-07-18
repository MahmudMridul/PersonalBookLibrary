using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    /* One user can have many books. 
     * One book can belong to many users (different copy)
     */
    public class UsersBooks
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
