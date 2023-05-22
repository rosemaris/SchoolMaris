using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace SchoolMaris.Model
{
    public class QuizQuestion
    {
        [Key]
        public int QQuestionID { get; set; }
        public string Question { get; set; }
        public int AKeyID { get; set; }
        public AnswerKey AnswerKey { get; set; }

        public int OptionID { get; set; }
        public Option Option { get; set; }

    }
}
