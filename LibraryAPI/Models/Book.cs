using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Published { get; set; }
    }
}
