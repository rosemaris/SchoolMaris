using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolMaris.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SchoolMaris.Pages.SubjectList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Subject Subject_ { get; set; }
        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost( )
        { 

            if (ModelState.IsValid)
            {
                var subjectWithSameName = _db.Subject
                                                  .Where(s => s.Code == Subject_.Code)
                                                  .ToList();
                if(subjectWithSameName.Count==0)
                {
                    Subject_.CreatedDate = DateTime.Now;
                    await _db.Subject.AddAsync(Subject_);
                    await _db.SaveChangesAsync();
                     return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError(" ", "Subject Code already exist");
                    return Page();
                }
            }
           return Page();
        }
    }
}
