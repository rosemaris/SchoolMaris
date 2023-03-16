using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace SchoolMaris.Model
{
    public class EnrolmentProfile
    {
        [Key]
        public int EnrolmentProfileID { get; set; }

        [Display(Name = "Enrollment Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
        public DateTime CreatedDate { get; set; }

        public int SchoolYear { get; set; }

       
        [Display(Name = "Pupils Profile")]
        public int PupilsProfileID { get; set; }
        public PupilsProfile PupilsProfile { get; set; }

       
       [Display(Name = "Level&Subject Teacher")]
       public int LevelSubjectTeacherID { get; set; }
       public LevelSubjectTeacher LevelSubjectTeacher { get; set; }
        
        /*
        [Display(Name = "Advisory Teacher")]
      public int LevelSectionTeacherID { get; set; }
      public LevelSectionTeacher LevelSectionTeacher { get; set; }
     */

        [Display(Name = "Last Updated Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
        public DateTime LastUpdatedDate { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> LevelSubjectTeacherLists { get; set; } = new List<SelectListItem>();
        [NotMapped]
        public IEnumerable<SelectListItem> PupilsLists { get; set; } = new List<SelectListItem>();
    }
}
