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
    public class CreateLevelSectionTeacherModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public LevelSectionTeacher LevelSectionTeacher_ { get; set; } = new LevelSectionTeacher();

        public CreateLevelSectionTeacherModel(ApplicationDbContext db)
        {
            _db = db;
        }



        
        public void OnGet ()
        {


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
                    Text = teacher.FirstName + " "+ teacher.LastName
                }).ToList() ;
        }
      

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var levelSectionTeacherWithSameSection = _db.LevelSectionTeacher
                                                  .Where(s => s.LevelSectionID == LevelSectionTeacher_.LevelSectionID  && LevelSectionTeacher_.LevelSectionTeacherID != s.LevelSectionTeacherID)
                                                  .ToList();
                if (levelSectionTeacherWithSameSection.Count == 0)
                {
                    LevelSectionTeacher_.CreatedDate = DateTime.Now;
                    await _db.LevelSectionTeacher.AddAsync(LevelSectionTeacher_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LevelSectionTeacherIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "LevelSectionTeacher already exist");
                    return Page();
                }
            }
            return Page();
        }


        /*
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
                                                  .Where(s => s.LevelSectionID == LevelSectionTeacher_.LevelSectionID && s.TeacherID == LevelSectionTeacher_.TeacherID && LevelSectionTeacher_.LevelSectionTeacherID != s.LevelSectionTeacherID)
                                                  .ToList();
                if (levelSectionTeacherWithSameSection.Count == 0)
                {
                    LevelSectionTeacher_.CreatedDate = DateTime.Now;
                    await _db.LevelSectionTeacher.AddAsync(LevelSectionTeacher_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LevelSectionTeacherIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "LevelSectionTeacher already exist");
                    return Page();
                }
            }
            return Page();
        }
        */
    }
}
