using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

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

        [NotMapped]
        public IEnumerable<SelectListItem> CredentialLists { get; set; } = new List<SelectListItem>();
    }
}
