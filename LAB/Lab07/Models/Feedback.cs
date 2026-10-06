using System.ComponentModel.DataAnnotations;

namespace Lab07.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your feedback")]
        [StringLength(500, MinimumLength = 10,
            ErrorMessage = "Feedback must be between 10 and 500 characters")]
        [Display(Name = "Feedback")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Please give a rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
    }
}