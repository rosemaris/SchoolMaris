using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Linq;
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

        public IList<LevelSubject> LevelSubject_ { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? LSubSearchString { get; set; }
        public SelectList? Codes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? LSubCode { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.LevelSubject
                                           orderby m.Level.Code
                                           select m.Level.Code;
            var levelsubject = from m in _db.LevelSubject
                        select m;
            if (!string.IsNullOrEmpty(LSubSearchString))
            {
                levelsubject = levelsubject.Where(s => s.Subject.Description.Contains(LSubSearchString));
            }

            if (!string.IsNullOrEmpty(LSubCode))
            {
                levelsubject = levelsubject.Where(x => x.Level.Code == LSubCode);
            }
            Codes = new SelectList(await codeQuery.Distinct().ToListAsync());
            LevelSubject_ = await levelsubject.Include(x => x.Subject).Include(x => x.Level).ToListAsync();
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
