namespace Quipu_task.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        public string SubTitle { get; set; }

        [Required]
        public int AuthorId { get; set; }

        // Navigation property
        public Author Author { get; set; }
    }
}
