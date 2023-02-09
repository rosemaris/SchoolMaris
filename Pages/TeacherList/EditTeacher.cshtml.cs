using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.TeacherList
{
    public class EditTeacherModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditTeacherModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Teacher Teacher_ { get; set; }
        public async Task OnGet(int id)
        {
            Teacher_ = await _db.Teacher.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                    var TeacherFromDb = await _db.Teacher.FindAsync(Teacher_.TeacherID);
                    TeacherFromDb.FirstName = Teacher_.FirstName;
                    TeacherFromDb.LastName = Teacher_.LastName;
                    TeacherFromDb.DateOfBirth = Teacher_.DateOfBirth;
                TeacherFromDb.Age = Teacher_.Age;
                TeacherFromDb.Gender = Teacher_.Gender;
                TeacherFromDb.Address = Teacher_.Address;
                TeacherFromDb.LastUpdatedDate = DateTime.Now;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("TeacherIndex");
            }
            return Page();
        }
    }
}
