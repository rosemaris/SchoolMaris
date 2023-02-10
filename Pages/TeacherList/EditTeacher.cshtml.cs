using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.Linq;
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
                var TeacherWithSameName = _db.Teacher
                                                      .Where(s => Teacher_.TeacherID != s.TeacherID)
                                                      .ToList();
                if (TeacherWithSameName.Count == 0)
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
