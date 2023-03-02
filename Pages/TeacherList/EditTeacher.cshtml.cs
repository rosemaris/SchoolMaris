using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.IO;
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
            byte[] bytes = null;
            if (Teacher_.ImageFile != null)
            {
                using (Stream fs = Teacher_.ImageFile.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }
                }
                Teacher_.TeachersImage = Convert.ToBase64String(bytes, 0, bytes.Length);
            }



            var TeacherWithSameName = _db.Teacher
                                                      .Where(s =>s.FirstName == Teacher_.FirstName && s.LastName == Teacher_.LastName &&
                                                      s.DateOfBirth == Teacher_.DateOfBirth && s.Age == Teacher_.Age && s.Gender == Teacher_.Gender &&
                                                      s.Address == Teacher_.Address && s.TeacherID !=Teacher_.TeacherID  )
                                                      .ToList();
                if (TeacherWithSameName.Count == 0)
                {
                    var TeacherFromDb = await _db.Teacher.FindAsync(Teacher_.TeacherID);
                    TeacherFromDb.TeachersImage = Teacher_.TeachersImage;
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
    }
}
