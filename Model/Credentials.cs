using System.ComponentModel.DataAnnotations;

namespace SchoolMaris.Model
{
    public class Credentials
    {
        [Key]
        public int CredentialID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
