using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.LevelSectionList
{
    public class LevelSectionIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public LevelSectionIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<LevelSection> LevelSection_ { get; set; }
        public async Task OnGet()
        {
            LevelSection_ = await _db.LevelSection.Include(x => x.Section).Include(x => x.Level).ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var levelSection = await _db.LevelSection.FindAsync(id);
            if (levelSection == null)
            {
                return NotFound();
            }

            _db.LevelSection.Remove(levelSection);
            await _db.SaveChangesAsync();
            return RedirectToPage("LevelSectionIndex");
        }
    }
}
