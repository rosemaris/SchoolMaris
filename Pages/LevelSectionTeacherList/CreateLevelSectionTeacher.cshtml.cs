using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SchoolMaris.Pages.LevelSectionTeacherList
{
    public class CreateLevelSectionTeacherModel : PageModel
    {/*
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public LevelSectionTeacher LevelSectionTeacher_ { get; set; } = new LevelSectionTeacher();

        public CreateLevelSectionTeacherModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            LevelSectionTeacher_.LevelSectionLists = _db.LevelSection.ToList()
            .Select(levelsection => new SelectListItem
            {
                Value = levelsection.LevelSectionID.ToString(),
                Text = levelsection.Section.Description.ToString()
            }).ToList();

            LevelSectionTeacher_.TeacherLists = _db.Teacher.ToList()
           .Select(levelsection => new SelectListItem
           {
               Value = levelsection.TeacherID.ToString(),
               Text = levelsection.FirstName.ToString()
           }).ToList();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var levelSectionTeacherWithSameSection = _db.LevelSectionTeacher
                                                  .Where(s => s.SectionID == LevelSection_.SectionID && s.LevelID == LevelSection_.LevelID && LevelSection_.LevelSectionID != s.LevelSectionID)
                                                  .ToList();
                if (levelSectionTeacherWithSameSection.Count == 0)
                {
                    LevelSection_.CreatedDate = DateTime.Now;
                    await _db.LevelSection.AddAsync(LevelSection_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LevelSectionIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "LevelSection already exist");
                    return Page();
                }
            }
            return Page();
        }
        */
    }
}
