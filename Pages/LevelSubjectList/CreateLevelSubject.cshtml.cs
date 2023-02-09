using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolMaris.Pages.LevelSubjectList
{
    public class CreateLevelSubjectModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public LevelSubject LevelSubject_ { get; set; }     = new LevelSubject();

        public CreateLevelSubjectModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            LevelSubject_.SubjectLists = _db.Subject.ToList()
            .Select(subject => new SelectListItem
             {
                 Value = subject.SubjectID.ToString(),
                 Text   = subject.Description.ToString()
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
                var levelSubjectWithSameSubject = _db.LevelSubject
                                                  .Where(s =>s.SubjectID == LevelSubject_.SubjectID && s.LevelID == LevelSubject_.LevelID  && LevelSubject_.LevelSubjectID != s.LevelSubjectID)
                                                  .ToList();
                if (levelSubjectWithSameSubject.Count == 0)
                {
                    LevelSubject_.CreatedDate = DateTime.Now;
                    await _db.LevelSubject.AddAsync(LevelSubject_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LevelSubjectIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "LevelSubject already exist");
                    return Page();
                }
            }
            return Page();
        }
    }
}
