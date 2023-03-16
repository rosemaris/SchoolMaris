using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.EnrolmentProfileList
{
    public class EnrolmentIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EnrolmentIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<EnrolmentProfile> EnrolmentProfile_ { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? ESearchString { get; set; }
        public SelectList? Codes { get; set; }
        [BindProperty(SupportsGet =true)]
        public string? ECode { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.EnrolmentProfile
                                           orderby m.LevelSubjectTeacher.LevelSubject.Level.Code
                                           select m.LevelSubjectTeacher.LevelSubject.Level.Code;
            var enrolment = from m in _db.EnrolmentProfile
                            select m;
            if (!string.IsNullOrEmpty(ESearchString))
            {
                enrolment = enrolment.Where(s => s.PupilsProfile.LastName.Contains(ESearchString));
            }

            if (!string.IsNullOrEmpty(ECode))
            {
                enrolment = enrolment.Where(s => s.LevelSubjectTeacher.LevelSubject.Level.Code == ECode);
            }

            Codes = new SelectList(await codeQuery.Distinct().ToListAsync());
            EnrolmentProfile_ = await enrolment.Include(x => x.LevelSubjectTeacher).Include(x => x.LevelSubjectTeacher.LevelSubject)
                .Include(x => x.LevelSubjectTeacher.LevelSubject.Level).Include(x=> x.LevelSubjectTeacher.LevelSubject.Subject)
                .Include(x=> x.PupilsProfile).Include(x=> x.LevelSubjectTeacher.Teacher).ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var enrolment = await _db.EnrolmentProfile.FindAsync(id);
            if (enrolment == null)
            {
                return NotFound();
            }

            _db.EnrolmentProfile.Remove(enrolment);
            await _db.SaveChangesAsync();
            return RedirectToPage("EnrolmentIndex");
        }
    }
}
