using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Web.Mvc;

namespace SchoolMaris.Model
{
    public class LevelSectionTeacher
    {
        [Key]
        public int LevelSectionTeacherID { get; set; }

        public int LevelSectionID { get; set; }
        public LevelSection LevelSection { get; set; }

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }


        [Display(Name = "Created Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Last Updated Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
        public DateTime LastUpdatedDate { get; set; }

        
        [NotMapped]
        public IEnumerable<SelectListItem> LevelSectionLists { get; set; } = new List<SelectListItem>();
        [NotMapped]
        public IEnumerable<SelectListItem> TeacherLists { get; set; } = new List<SelectListItem>();
        
    }
}
