using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Web.Mvc;

namespace SchoolMaris.Model
{
    public class LevelSection
    {
        [Key]
        public int LevelSectionID { get; set; }

        public int LevelID { get; set; }
        public Level Level { get; set; }

        public int SectionID { get; set; }
        public Section Section { get; set; }


        [Display(Name = "Created Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Last Updated Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
        public DateTime LastUpdatedDate { get; set; }

        public List<LevelSectionTeacher> LevelSectionTeachers { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> SectionLists { get; set; } = new List<SelectListItem>();
        [NotMapped]
        public IEnumerable<SelectListItem> LevelLists { get; set; } = new List<SelectListItem>();
    }
}
