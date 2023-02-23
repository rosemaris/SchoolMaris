using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolMaris.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolMaris.Pages.SubjectList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Subject> Subject_ { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string?  SearchString { get; set; }
        public SelectList? Codes { get; set; }
        [BindProperty(SupportsGet =true)]
        public string? SubjectCode { get; set; }

         public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.Subject
                                           orderby m.Code
                                           select m.Code;
            var subject = from m in _db.Subject
                          select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                subject = subject.Where(s => s.Description.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SubjectCode))
            {
                subject = subject.Where(x => x.Code == SubjectCode);
            }
            Codes = new SelectList(await codeQuery.Distinct().ToListAsync());
            Subject_ = await subject.ToListAsync();

        }
   
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var subject = await _db.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            
            _db.Subject.Remove(subject);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
       

    }
}
