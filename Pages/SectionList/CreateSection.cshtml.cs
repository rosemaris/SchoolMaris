using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.SectionList
{
    public class CreateSectionModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Section Section_ { get; set; }

        public CreateSectionModel(ApplicationDbContext db)
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
                var levelWithSameSection = _db.Section
                                                  .Where(s => s.Description == Section_.Description  && Section_.SectionID != s.SectionID)
                                                  .ToList();
                if (levelWithSameSection.Count == 0)
                {
                    Section_.CreatedDate = DateTime.Now;
                    await _db.Section.AddAsync(Section_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("SectionIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Section Name already exist");
                    return Page();
                }
            }
            return Page();
        }
    }
}
