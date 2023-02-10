using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.TeacherList
{
    public class CreateTeacherModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Teacher Teacher_ { get; set; }

        public CreateTeacherModel(ApplicationDbContext db)
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
                var TeacherWithSameName = _db.Teacher
                                                        .Where(s => s.FirstName == Teacher_.FirstName && s.LastName == Teacher_.LastName && Teacher_.TeacherID == s.TeacherID)
                                                        .ToList();
                if (TeacherWithSameName.Count == 0)
                {
                    Teacher_.CreatedDate = DateTime.Now;
                    await _db.Teacher.AddAsync(Teacher_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("TeacherIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Teacher Name already exist");
                    return Page();
                }
            }
            return Page();
        }
    }
}
