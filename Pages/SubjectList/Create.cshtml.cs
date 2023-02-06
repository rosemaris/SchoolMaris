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
        public Subject Subjects { get; set; }
        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost( )
        {
            if (ModelState.IsValid)
            {
                await _db.Subject.AddAsync( Subjects );
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
