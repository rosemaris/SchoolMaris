using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolMaris.Pages.LevelSubjectList
{
    public class EditLevelSubjectModel : PageModel
    {
        private ApplicationDbContext _db;
        [BindProperty]
        public LevelSubject LevelSubject_ { get; set; }
        public EditLevelSubjectModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            LevelSubject_ = await _db.LevelSubject.FindAsync(id);

            LevelSubject_.SubjectLists = _db.Subject.ToList()
            .Select(subject => new SelectListItem
            {
                Value = subject.SubjectID.ToString(),
                Text = subject.Description.ToString()
            }).ToList();

            LevelSubject_.LevelLists = _db.Level.ToList()
           .Select(subject => new SelectListItem
           {
               Value = subject.LevelID.ToString(),
               Text = subject.Code.ToString()
           }).ToList();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var levelwithSameSubject = _db.LevelSubject
                                                   .Where(s => s.SubjectID == LevelSubject_.SubjectID && LevelSubject_.LevelSubjectID != s.LevelSubjectID)
                                                   .Where(s => s.LevelID == LevelSubject_.LevelID && LevelSubject_.LevelSubjectID != s.LevelSubjectID)
                                                   .ToList();
                if (levelwithSameSubject.Count == 0)
                {
                    var levelSubjectFromDb = await _db.LevelSubject.FindAsync(LevelSubject_.LevelSubjectID);
                    levelSubjectFromDb.LevelID = LevelSubject_.LevelID;
                    levelSubjectFromDb.SubjectID = LevelSubject_.SubjectID;
                    levelSubjectFromDb.LastUpdatedDate = DateTime.Now;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LevelSubjectIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "LevelSubject already exist");
                    return Page();
                }
            }
            return RedirectToPage();
        }
    }
}
