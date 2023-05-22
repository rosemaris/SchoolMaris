using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.QUIZ
{
    public class AnswerKeyModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public AnswerKey AnswerKey_ { get; set; }
        public AnswerKeyModel(ApplicationDbContext db)
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
                var RepeatedAnswerKey = _db.AnswerKey
                                                 .Where(s => AnswerKey_.AnswerKeys == s.AnswerKeys && s.AKeyID != AnswerKey_.AKeyID)
                                                 .ToList();
                if (RepeatedAnswerKey.Count == 0)
                {

                    await _db.AnswerKey.AddAsync(AnswerKey_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("AnswerKeyIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "AnswerKey already exist");
                    return Page();
                }
            }
            return Page();
        }
    }
}
