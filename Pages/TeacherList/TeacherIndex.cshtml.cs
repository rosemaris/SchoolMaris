using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Linq;
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

        public IList<Teacher> Teacher_ { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? TSearchString { get; set; }
        public SelectList? Codes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? TCode { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.Teacher
                                           orderby m.Gender
                                           select m.Gender;
            var teacher = from m in _db.Teacher
                          select m;
            if (!string.IsNullOrEmpty(TSearchString))
            {
                teacher = teacher.Where(s => s.LastName.Contains(TSearchString));
            }

            if (!string.IsNullOrEmpty(TCode))
            {
                teacher = teacher.Where(x => x.Gender == TCode);
            }
            Codes = new SelectList(await codeQuery.Distinct().ToListAsync());
            Teacher_ = await teacher.ToListAsync();
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
