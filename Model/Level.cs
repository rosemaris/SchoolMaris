using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolMaris.Model
{
    public class Level
    {

        [Key]
        public int LevelID { get; set; }

        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }

        [Display(Name = "Created Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Updated Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
        public DateTime? LastUpdatedDate { get; set; }

        public List<LevelSubject> LevelSubjects { get; set; }
    }
}
