using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMaris.Model
{
    public class PupilsProfile
    {
        [Key]
        public int PupilsProfileID { get; set; }
        [Required]
        [Display(Name = "Pupils' Profile")]
        public string PupilsImage { get;set; }
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        [Display(Name = "Created Date")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Last Updated Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy hh:mm tt}")]
        public DateTime LastUpdatedDate { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
