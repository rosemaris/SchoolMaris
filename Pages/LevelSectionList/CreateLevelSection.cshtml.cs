using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SchoolMaris.Pages.LevelSectionList
{
    public class CreateLevelSectionModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public LevelSection LevelSection_ { get; set; } = new LevelSection();

        public CreateLevelSectionModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            LevelSection_.SectionLists = _db.Section.ToList()
            .Select(section => new SelectListItem
            {
                Value = section.SectionID.ToString(),
                Text = section.Description.ToString()
            }).ToList();

            LevelSection_.LevelLists = _db.Level.ToList()
           .Select(level => new SelectListItem
           {
               Value = level.LevelID.ToString(),
               Text = level.Code.ToString()
           }).ToList();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var levelSectionWithSameSection = _db.LevelSection
                                                  .Where(s => s.LevelID == LevelSection_.LevelID && s.SectionID == LevelSection_.SectionID && LevelSection_.LevelSectionID != s.LevelSectionID)
                                                  .ToList();
                if (levelSectionWithSameSection.Count == 0)
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
    }
}
