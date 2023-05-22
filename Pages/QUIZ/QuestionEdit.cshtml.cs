using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Linq;
using System.Threading.Tasks;


namespace SchoolMaris.Pages.QUIZ
{
    public class QuestionEditModel : PageModel
    {
        private ApplicationDbContext _db;
        [BindProperty]
        public QuizQuestion QuizQuestion_ { get; set; }
        public QuestionEditModel(ApplicationDbContext db) 
        {
            _db = db;
        }
        public async Task OnGet(int id)
        {
            QuizQuestion_ = await _db.QuizQuestion.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var RepeatedQuestion = _db.QuizQuestion
                                                  .Where(s => QuizQuestion_.Question != QuizQuestion_.Question && s.QQuestionID == QuizQuestion_.QQuestionID)
                                                  .ToList();
                if (RepeatedQuestion.Count == 0)
                {

                    var questionDB = await _db.QuizQuestion.FindAsync(QuizQuestion_.QQuestionID);
                    questionDB.Question = QuizQuestion_.Question;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("QuestionIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Question already exist");
                    return Page();
                }
            }
            return RedirectToPage();
        }
    }
}
