using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.QUIZ
{
    public class OptionIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public OptionIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Option> Option_ { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? OSearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? OCode { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.Option
                                           orderby m.Options
                                           select m.Options;
            var optionss = from m in _db.Option
                            select m;

            if (!string.IsNullOrEmpty(OCode))
            {
                optionss = optionss.Where(x => x.Options == OCode);
            }
            Option_ = await optionss.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var optionss = await _db.Option.FindAsync(id);
            if (optionss == null)
            {
                return NotFound();
            }

            _db.Option.Remove(optionss);
            await _db.SaveChangesAsync();
            return RedirectToPage("OptionIndex");
        }
    }
}
