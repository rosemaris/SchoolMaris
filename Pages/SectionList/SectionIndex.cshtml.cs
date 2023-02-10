using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
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

        public IEnumerable<Section> Section_ { get; set; }
        public async Task OnGet()
        {
            Section_ = await _db.Section.ToListAsync();
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
