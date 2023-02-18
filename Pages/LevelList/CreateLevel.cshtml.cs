using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.LevelList
{
    public class CreateLevelModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Level Level_ { get; set; }

        public CreateLevelModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var levelWithSameName = _db.Level
                                                  .Where(s => s.Code == Level_.Code)
                                                  .ToList();
                if (levelWithSameName.Count == 0)
                {
                    Level_.CreatedDate = DateTime.Now;
                    await _db.Level.AddAsync(Level_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LevelIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Level Code already exist");
                    return Page();
                }
            }
            return Page();
        }
    }
}
