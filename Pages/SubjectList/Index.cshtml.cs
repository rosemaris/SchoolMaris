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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Subject> Subject_ { get; set; }
        public async Task OnGet()
        {
            Subject_ = await _db.Subject.ToListAsync();
        }
     
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var subject = await _db.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            
            _db.Subject.Remove(subject);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }


    }
}
