using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.SubjectList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db=db;
        }
        [BindProperty]
        public Subject Subject_ { get; set; }
        public async Task OnGet(int id)
        {
            Subject_ = await _db.Subject.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var subjectWithSameName = _db.Subject
                                                    .Where(s => s.Code == Subject_.Code && Subject_.SubjectID != s.SubjectID)
                                                    .ToList();
                if (subjectWithSameName.Count == 0)
                {
                    var SubjectFromDb = await _db.Subject.FindAsync(Subject_.SubjectID);
                    SubjectFromDb.Unit = Subject_.Unit;
                    SubjectFromDb.Code = Subject_.Code;
                    SubjectFromDb.Description = Subject_.Description;
                    SubjectFromDb.LastUpdatedDate = DateTime.Now;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError(" ", "Subject Code already exist");
                    return Page();
                }
            }
            return Page();
        }
    }
}
