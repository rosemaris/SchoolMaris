using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolMaris.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SchoolMaris.Pages.SubjectList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Subject> Subjects { get; set; }
        public async Task OnGet()
        {
            Subjects = await _db.Subject.ToListAsync();
        }
    }
}
