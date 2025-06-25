using System.ComponentModel.DataAnnotations;

namespace BookValidationApp.Models
{
    public class Book
    {
        [Required(ErrorMessage = "ISBN is required")]
        public int Isbn { get; set; }

        [Required(ErrorMessage = "Book name is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Book name must be 1 to 20 characters")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Author name must be 1 to 50 characters")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Published Date is required")]
        [PublishedDateValidation]
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "Book URL is required")]
        [Url(ErrorMessage = "Enter a valid URL")]
        public string BookUrl { get; set; }
    }
}
