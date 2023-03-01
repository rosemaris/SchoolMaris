using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolMaris.Pages.LevelSectionTeacherList
{
    public class EditLevelSectionTeacherModel : PageModel
    {
        private ApplicationDbContext _db;

        [BindProperty]
        public LevelSectionTeacher LevelSectionTeacher_ { get; set; }
        public EditLevelSectionTeacherModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            LevelSectionTeacher_ = await _db.LevelSectionTeacher.FindAsync(id);

            LevelSectionTeacher_.LevelSectionLists = _db.LevelSection.Include(x => x.Section).Include(x => x.Level).ToList()
               .Select(levelsection => new SelectListItem
               {
                   Value = levelsection.LevelSectionID.ToString(),
                   Text = levelsection.Level.Code + "-" + levelsection.Section.Description
               }).ToList();

            LevelSectionTeacher_.TeacherLists = _db.Teacher.ToList()
                .Select(teacher => new SelectListItem
                {
                    Value = teacher.TeacherID.ToString(),
                    Text = teacher.FirstName + " " + teacher.LastName
                }).ToList();
        }
        public async Task <IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var teachingAdvisoryWithSameTeacher = _db.LevelSectionTeacher
                    .Where(s => s.LevelSectionID == LevelSectionTeacher_.LevelSectionID && s.LevelSectionTeacherID != LevelSectionTeacher_.LevelSectionTeacherID)
                    .ToList();
                if (teachingAdvisoryWithSameTeacher.Count == 0)
                {
                    var teachingAdvisoryFromDb = await _db.LevelSectionTeacher.FindAsync(LevelSectionTeacher_.LevelSectionTeacherID);
                    teachingAdvisoryFromDb.LevelSectionID = LevelSectionTeacher_.LevelSectionID;
                    teachingAdvisoryFromDb.TeacherID = LevelSectionTeacher_.TeacherID;
                    teachingAdvisoryFromDb.LastUpdatedDate = DateTime.Now;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LevelSectionTeacherIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Teaching Advisory already exist");
                    return Page();
                }
            }
            return RedirectToPage();
        }
        

    }
}
