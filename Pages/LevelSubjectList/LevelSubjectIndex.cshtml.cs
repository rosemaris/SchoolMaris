using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.LevelSubjectList
{
    public class LevelSubjectIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public LevelSubjectIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<LevelSubject> LevelSubject_ { get; set; }
        public async Task OnGet()
        {
            LevelSubject_ = await _db.LevelSubject.Include(x=>x.Subject).Include(x=>x.Level).ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var levelsubject = await _db.LevelSubject.FindAsync(id);
            if (levelsubject == null)
            {
                return NotFound();
            }

            _db.LevelSubject.Remove(levelsubject);
            await _db.SaveChangesAsync();
            return RedirectToPage("LevelSubjectIndex");
        }

    }
}
