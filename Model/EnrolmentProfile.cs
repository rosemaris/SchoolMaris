using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
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
        
        [Required]
        public int SchoolYear { get; set; }
        /*
       [Required]
       [Display(Name = "Pupil")]
       public int PupilsProfileID { get; set; }
       public PupilsProfile PupilsProfile { get; set; }

       [Required]
       [Display(Name = "Classroom Adviser")]
       public int LevelSectionTeacherID { get; set; }
       public LevelSectionTeacher LevelSectionTeacher { get; set; }

       [Required]
       [Display(Name = "Subject Teacher")]
       public int LevelSubjectTeacherID { get; set; }
       public LevelSubjectTeacher LevelSubjectTeacher { get; set; }


       [Display(Name = "Last Updated Date")]
       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
       public DateTime LastUpdatedDate { get; set; }
       */
    }

}
