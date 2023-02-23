using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Linq;
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


        public IList<Level> Level_ { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? LSearchString { get; set; }
        public SelectList? Codes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? LevelCode { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.Level
                                           orderby m.Code
                                           select m.Code;
            var level = from m in _db.Level
                          select m;
            if (!string.IsNullOrEmpty(LSearchString))
            {
                level = level.Where(s => s.Description.Contains(LSearchString));
            }

            if (!string.IsNullOrEmpty(LevelCode))
            {
                level = level.Where(x => x.Code == LevelCode);
            }
            Codes = new SelectList(await codeQuery.Distinct().ToListAsync());
            Level_ = await level.ToListAsync();
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
