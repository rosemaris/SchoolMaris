using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolMaris.Model
{
    public class Option
    {
        [Key]
        public int OptionID { get; set; }
        public string Options { get; set; }
        public List<QuizQuestion> QuizQuestion { get; set; }
    }
}
