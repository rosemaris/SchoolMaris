using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.LevelList
{
    public class LevelIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public LevelIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Level> Level_ { get; set; }
        public async Task OnGet()
        {
            Level_ = await _db.Level.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var level = await _db.Level.FindAsync(id);
            if (level == null)
            {
                return NotFound();
            }

            _db.Level.Remove(level);
            await _db.SaveChangesAsync();
            return RedirectToPage("LevelIndex");
        }
    }
}
