using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Linq;
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

        public IList<LevelSection> LevelSection_ { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? LSecSearchString { get; set; }
        public SelectList? Codes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? LSecCode { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.LevelSection
                                           orderby m.Level.Code
                                           select m.Level.Code;
            var levelsection = from m in _db.LevelSection
                               select m;
            if (!string.IsNullOrEmpty(LSecSearchString))
            {
                levelsection = levelsection.Where(s => s.Section.Description.Contains(LSecSearchString));
            }

            if (!string.IsNullOrEmpty(LSecCode))
            {
                levelsection = levelsection.Where(x => x.Level.Code == LSecCode);
            }
            Codes = new SelectList(await codeQuery.Distinct().ToListAsync());
            LevelSection_ = await levelsection.Include(x => x.Section).Include(x => x.Level).ToListAsync();
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
