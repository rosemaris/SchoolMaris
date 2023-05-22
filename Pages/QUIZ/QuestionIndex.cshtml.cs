using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.QUIZ
{
    public class QuestionIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public QuestionIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<QuizQuestion> QuizQuestion_ { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? QSearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? QCode { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> codeQuery = from m in _db.QuizQuestion
                                           orderby m.Question
                                           select m.Question;
            var question = from m in _db.QuizQuestion
                            select m;

            if (!string.IsNullOrEmpty(QCode))
            {
                question = question.Where(x => x.Question == QCode);
            }
            QuizQuestion_ = await question.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var question = await _db.QuizQuestion.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _db.QuizQuestion.Remove(question);
            await _db.SaveChangesAsync();
            return RedirectToPage("QuestionIndex");
        }
    }
}
