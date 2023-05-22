using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.QUIZ
{
    public class QuestionModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public QuizQuestion QuizQuestion_ { get; set; }
        public AnswerKey AnswerKey_ { get; set; }
        public QuestionModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var RepeatedQuestion = _db.QuizQuestion
                                                 .Where(s => QuizQuestion_.Question == s.Question && s.QQuestionID != QuizQuestion_.QQuestionID)
                                                 .ToList();
                if (RepeatedQuestion.Count == 0)
                {

                    await _db.QuizQuestion.AddAsync(QuizQuestion_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("QuestionIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Question already exist");
                    return Page();
                }

            }
            return Page();


        }
    }
}
