using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace SchoolMaris.Model
{
    public class LevelSubject
    {
        [Key]
        public int LevelSubjectID { get; set; }

        public int LevelID { get; set; }
        public Level Level { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
    

        [Display(Name = "Created Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Updated Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
        public DateTime? LastUpdatedDate { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem> SubjectLists { get; set; } = new List<SelectListItem>();
        [NotMapped]
        public IEnumerable<SelectListItem> LevelLists { get; set; } = new List<SelectListItem>();

    }
}
