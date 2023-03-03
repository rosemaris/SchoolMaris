using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.LevelSubjectTeacherList
{
    public class LevelSubjectTeacherIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public LevelSubjectTeacherIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<LevelSubjectTeacher> LevelSubjectTeacher_ { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? LSubTeachSearchString { get; set; }
        public SelectList? Codes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? LSubTeachCode { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.LevelSubjectTeacher
                                           orderby m.LevelSubject.Level.Code
                                           select m.LevelSubject.Level.Code;

            var levelsubjectteacher = from m in _db.LevelSubjectTeacher
                                      select m;
            if(!string.IsNullOrEmpty(LSubTeachSearchString))
            {
                levelsubjectteacher = levelsubjectteacher.Where(s => s.Teacher.LastName.Contains(LSubTeachSearchString));
            }
            if (!string.IsNullOrEmpty(LSubTeachCode))
            {
                levelsubjectteacher = levelsubjectteacher.Where(x => x.LevelSubject.Level.Code == LSubTeachCode);
            }
            Codes = new SelectList(await codeQuery.Distinct().ToListAsync());
            LevelSubjectTeacher_ = await levelsubjectteacher.Include(x=> x.LevelSubject).Include(x=> x.LevelSubject.Subject)
                .Include(x=> x.LevelSubject.Level).Include(x=> x.Teacher).ToListAsync();

        }
        public async Task <IActionResult> OnPostDelete(int id)
        {
            var levelsubjectteacher = await _db.LevelSubjectTeacher.FindAsync(id);
            if(levelsubjectteacher == null)
            {
                return NotFound();
            }

            _db.LevelSubjectTeacher.Remove(levelsubjectteacher);
            await _db.SaveChangesAsync();
            return RedirectToPage("LevelSubjectTeacherIndex");
        }


    }
}
