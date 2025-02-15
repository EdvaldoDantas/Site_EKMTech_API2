using System.ComponentModel.DataAnnotations;
namespace Site_EKMTech_API2.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        public DateOnly DateOfBirth { get; set; }
    }
}
