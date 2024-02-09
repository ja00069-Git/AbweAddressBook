using System.ComponentModel.DataAnnotations;

namespace AbweAddressBook.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter your fist name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string? LastName { get; set; }

        public string? NickName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string? PhoneNumber { get; set; }

        public DateTime? DateCreated { get; set; } = DateTime.Now.Date;
    }
}
