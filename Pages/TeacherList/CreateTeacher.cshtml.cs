using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
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
                    Teacher_.CreatedDate = DateTime.Now;
                    await _db.Teacher.AddAsync(Teacher_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("TeacherIndex");
            }
            return Page();
        }
    }
}
