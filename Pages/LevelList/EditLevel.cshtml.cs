using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace SchoolMaris.Pages.LevelList
{
    public class EditLevelModel : PageModel
    {
        private ApplicationDbContext _db;
        [BindProperty]
        public Level Level_ { get; set; }
        public EditLevelModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            Level_ = await _db.Level.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var levelWithSameName = _db.Level
                                                   .Where(s => s.Code == Level_.Code && Level_.LevelID != s.LevelID)
                                                   .ToList();
                if (levelWithSameName.Count == 0)
                {
                    var levelFromDb = await _db.Level.FindAsync(Level_.LevelID);
                    levelFromDb.Code = Level_.Code;
                    levelFromDb.Description = Level_.Description;
                    levelFromDb.LastUpdatedDate = DateTime.Now;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LevelIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Level Code already exist");
                    return Page();
                }
            }
            return RedirectToPage();
        }
    }
}
