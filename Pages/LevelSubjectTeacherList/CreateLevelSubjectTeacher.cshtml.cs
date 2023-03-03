using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web.Mvc;

namespace SchoolMaris.Pages.LevelSubjectTeacherList
{
    public class CreateLevelSubjectTeacherModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public LevelSubjectTeacher LevelSubjectTeacher_ { get; set; } = new LevelSubjectTeacher();

        public CreateLevelSubjectTeacherModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {


            LevelSubjectTeacher_.LevelSubjectLists = _db.LevelSubject.Include(x => x.Subject).Include(x => x.Level).ToList()
                .Select(LevelSubject => new SelectListItem
                {
                    Value = LevelSubject.LevelSubjectID.ToString(),
                    Text = LevelSubject.Level.Code + "-" + LevelSubject.Subject.Description


                }).ToList();

            LevelSubjectTeacher_.TeacherLists = _db.Teacher.ToList()
                .Select(teacher => new SelectListItem
                {
                    Value = teacher.TeacherID.ToString(),
                    Text = teacher.FirstName + " " + teacher.LastName
                }).ToList();
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var levelSubjectTeacherWithSameSection = _db.LevelSubjectTeacher
                                                  .Where(s => s.LevelSubjectID == LevelSubjectTeacher_.LevelSubjectID && LevelSubjectTeacher_.LevelSubjectTeacherID != s.LevelSubjectTeacherID)
                                                  .ToList();
                if (levelSubjectTeacherWithSameSection.Count == 0)
                {
                    LevelSubjectTeacher_.CreatedDate = DateTime.Now;
                    await _db.LevelSubjectTeacher.AddAsync(LevelSubjectTeacher_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LevelSubjectTeacherIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Teaching Subject Class already exist");
                    return Page();
                }
            }
            return Page();
        }
    }
}
