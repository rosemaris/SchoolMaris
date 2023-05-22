using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.QUIZ
{
    public class AnswerKeyEditModel : PageModel
    {

        private ApplicationDbContext _db;
        [BindProperty]
        public AnswerKey AnswerKey_ { get; set; }
        public AnswerKeyEditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            AnswerKey_ = await _db.AnswerKey.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var RepeatedAnswerKey = _db.AnswerKey
                                                  .Where(s => AnswerKey_.AnswerKeys == s.AnswerKeys && s.AKeyID != AnswerKey_.AKeyID)
                                                  .ToList();
                if (RepeatedAnswerKey.Count == 0)
                {

                    var answerKeyDB = await _db.AnswerKey.FindAsync(AnswerKey_.AnswerKeys);
                    answerKeyDB.AnswerKeys = AnswerKey_.AnswerKeys;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("AnswerKeyIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "AnswerKey already exist");
                    return Page();
                }
            }
            return RedirectToPage();
        }
    }
}
