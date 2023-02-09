using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.TeacherList
{
    public class TeacherIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public TeacherIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Teacher> Teacher_ { get; set; }
        public async Task OnGet()
        {
            Teacher_ = await _db.Teacher.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var teacher = await _db.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _db.Teacher.Remove(teacher);
            await _db.SaveChangesAsync();
            return RedirectToPage("TeacherIndex");
        }
    }
}
