using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.SectionList
{
    public class SectionIndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public SectionIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public IList<Section> Section_ { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SecSearchString { get; set; }
        public SelectList? Codes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SectionCode { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.Section
                                           orderby m.Code
                                           select m.Code;
            var section = from m in _db.Section
                        select m;
            if (!string.IsNullOrEmpty(SecSearchString))
            {
                section = section.Where(s => s.Description.Contains(SecSearchString));
            }

            if (!string.IsNullOrEmpty(SectionCode))
            {
                section = section.Where(x => x.Code == SectionCode);
            }
            Codes = new SelectList(await codeQuery.Distinct().ToListAsync());
            Section_ = await section.ToListAsync();
        }


        public async Task<IActionResult> OnPostDelete(int id)
        {
            var section = await _db.Section.FindAsync(id);
            if (section == null)
            {
                return NotFound();
            }

            _db.Section.Remove(section);
            await _db.SaveChangesAsync();
            return RedirectToPage("SectionIndex");
        }
    }
}
