using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.SectionList
{
    public class EditSectionModel : PageModel
    {
        private ApplicationDbContext _db;
        [BindProperty]
        public Section Section_ { get; set; }
        public EditSectionModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            Section_ = await _db.Section.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var SectionWithSameName = _db.Section
                                                   .Where(s => s.Description == Section_.Description && Section_.SectionID != s.SectionID)
                                                   .ToList();
                if (SectionWithSameName.Count == 0)
                {
                    var sectionFromDb = await _db.Section.FindAsync(Section_.SectionID);
                    sectionFromDb.Code = Section_.Code;
                    sectionFromDb.Description = Section_.Description;
                    sectionFromDb.LastUpdatedDate = DateTime.Now;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("SectionIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Section Name already exist");
                    return Page();
                }
            }
            return RedirectToPage();
        }
    }
}
