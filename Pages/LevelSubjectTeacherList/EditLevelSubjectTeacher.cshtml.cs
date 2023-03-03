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
    public class EditLevelSubjectTeacherModel : PageModel
    {
        private ApplicationDbContext _db;

        [BindProperty]
        public LevelSubjectTeacher LevelSubjectTeacher_ { get; set; }
        public EditLevelSubjectTeacherModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            LevelSubjectTeacher_ = await _db.LevelSubjectTeacher.FindAsync(id);

            LevelSubjectTeacher_.LevelSubjectLists = _db.LevelSubject.Include(x => x.Subject).Include(x => x.Level).ToList()
               .Select(levelsubject => new SelectListItem
               {
                   Value = levelsubject.LevelSubjectID.ToString(),
                   Text = levelsubject.Level.Code + "-" + levelsubject.Subject.Description
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
                var teachingSubjectClassWithSameTeacher = _db.LevelSubjectTeacher
                    .Where(s => s.LevelSubjectID == LevelSubjectTeacher_.LevelSubjectID && s.LevelSubjectTeacherID != LevelSubjectTeacher_.LevelSubjectTeacherID)
                    .ToList();
                if (teachingSubjectClassWithSameTeacher.Count == 0)
                {
                    var teachingSubjectClassFromDb = await _db.LevelSubjectTeacher.FindAsync(LevelSubjectTeacher_.LevelSubjectTeacherID);
                    teachingSubjectClassFromDb.LevelSubjectID = LevelSubjectTeacher_.LevelSubjectID;
                    teachingSubjectClassFromDb.TeacherID = LevelSubjectTeacher_.TeacherID;
                    teachingSubjectClassFromDb.LastUpdatedDate = DateTime.Now;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LevelSubjectTeacherIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Teaching Subject Class already exist");
                    return Page();
                }
            }
            return RedirectToPage();
        }


    }
}
