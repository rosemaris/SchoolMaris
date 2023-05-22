using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.QUIZ
{
    public class AnswerKeyIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AnswerKeyIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<AnswerKey> AnswerKey_ { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? AKSearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? AKCode { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.AnswerKey
                                           orderby m.AnswerKeys
                                           select m.AnswerKeys;
            var answerKey = from m in _db.AnswerKey
                         select m;

            if (!string.IsNullOrEmpty(AKCode))
            {
                answerKey = answerKey.Where(x => x.AnswerKeys == AKCode);
            }
            AnswerKey_ = await answerKey.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var answerKey = await _db.AnswerKey.FindAsync(id);
            if (answerKey == null)
            {
                return NotFound();
            }

            _db.AnswerKey.Remove(answerKey);
            await _db.SaveChangesAsync();
            return RedirectToPage("AnswerKeyIndex");
        }
    }
}
