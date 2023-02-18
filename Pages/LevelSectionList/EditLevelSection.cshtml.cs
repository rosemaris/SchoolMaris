using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SchoolMaris.Pages.LevelSectionList
{
    public class EditLevelSectionModel : PageModel
    {
        private ApplicationDbContext _db;
        [BindProperty]
        public LevelSection LevelSection_ { get; set; }
        public EditLevelSectionModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            LevelSection_ = await _db.LevelSection.FindAsync(id);

            LevelSection_.SectionLists = _db.Section.ToList()
            .Select(subject => new SelectListItem
            {
                Value = subject.SectionID.ToString(),
                Text = subject.Description.ToString()
            }).ToList();

            LevelSection_.LevelLists = _db.Level.ToList()
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
                var levelwithSameSection = _db.LevelSection
                                                   .Where(s => s.SectionID == LevelSection_.SectionID && LevelSection_.LevelSectionID != s.LevelSectionID)
                                                   .Where(s => s.LevelID == LevelSection_.LevelID && LevelSection_.LevelSectionID != s.LevelSectionID)
                                                   .ToList();
                if (levelwithSameSection.Count == 0)
                {
                    var levelSectionFromDb = await _db.LevelSection.FindAsync(LevelSection_.LevelSectionID);
                    levelSectionFromDb.LevelID = LevelSection_.LevelID;
                    levelSectionFromDb.SectionID = LevelSection_.SectionID;
                    levelSectionFromDb.LastUpdatedDate = DateTime.Now;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LevelSectionIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "LevelSection already exist");
                    return Page();
                }
            }
            return RedirectToPage();
        }
    }
}
