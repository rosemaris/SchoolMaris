using System.ComponentModel.DataAnnotations;

namespace SchoolMaris.Model
{
    public class Subject
    {
        [Key]
        public int  SubjectID { get; set; }
        [Required]
        public int Unit { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
    }
}
