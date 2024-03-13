using System.ComponentModel.DataAnnotations;

namespace API
{
    public class SignUpModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
