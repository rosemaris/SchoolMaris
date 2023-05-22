using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolMaris.Model
{
    public class AnswerKey
    {
        [Key] 
        public int AKeyID { get; set; }
        public string AnswerKeys { get; set; }
        public List<QuizQuestion> QuizQuestion { get; set; }
    }
}
