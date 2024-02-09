using System.ComponentModel.DataAnnotations;

namespace AbweAddressBook.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter your fist name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed in the first name.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed in the last name.")]
        public string? LastName { get; set; }

        public string? NickName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter a valid phone number")]
        public string? PhoneNumber { get; set; }

        public DateTime? DateCreated { get; set; } = DateTime.Now;
    }
}
