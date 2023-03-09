using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using SchoolMaris.Model;
using System;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

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

                
                var TeacherWithSameData = _db.Teacher
                                        .Where(s => s.FirstName == Teacher_.FirstName && s.LastName == Teacher_.LastName)
                                        .ToList();

                if (TeacherWithSameData.Count == 0)
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
    }
}
