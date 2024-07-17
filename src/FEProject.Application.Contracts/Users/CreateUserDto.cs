using System.ComponentModel.DataAnnotations;

namespace FEProject.Users
{
    public class CreateUserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        // Add other necessary properties
    }
}
