using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.LevelSectionTeacherList
{
    public class LevelSectionTeacherIndexModel : PageModel
    {


        
        private readonly ApplicationDbContext _db;

        public LevelSectionTeacherIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<LevelSectionTeacher> LevelSectionTeacher_ { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? LSecTeachSearchString { get; set; }
        public SelectList? Codes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? LSecTeachCode { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.LevelSectionTeacher
                                           orderby m.LevelSection.Level.Code
                                           select m.LevelSection.Level.Code;

            var levelsectionteacher = from m in _db.LevelSectionTeacher
                               select m;
            if (!string.IsNullOrEmpty(LSecTeachSearchString))
            {
              
                levelsectionteacher = levelsectionteacher.Where(s => s.Teacher.LastName.Contains(LSecTeachSearchString));
            }

            if (!string.IsNullOrEmpty(LSecTeachCode))
            {
                levelsectionteacher = levelsectionteacher.Where(x => x.LevelSection.Level.Code == LSecTeachCode);
            }
            Codes = new SelectList(await codeQuery.Distinct().ToListAsync());
            LevelSectionTeacher_ = await levelsectionteacher.Include(x => x.LevelSection).Include(x => x.LevelSection.Section)
                .Include(x => x.LevelSection.Level).Include(x => x.Teacher).ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var levelsectionteacher = await _db.LevelSectionTeacher.FindAsync(id);
            if (levelsectionteacher == null)
            {
                return NotFound();
            }

            _db.LevelSectionTeacher.Remove(levelsectionteacher);
            await _db.SaveChangesAsync();
            return RedirectToPage("LevelSectionTeacherIndex");
        }
    }
}
