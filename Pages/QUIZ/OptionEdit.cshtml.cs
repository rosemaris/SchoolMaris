using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.QUIZ
{
    public class OptionEditModel : PageModel
    {

        private ApplicationDbContext _db;

        [BindProperty]
        public Option Option_ { get; set; }
        public OptionEditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            Option_ = await _db.Option.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var RepeatedOption = _db.Option
                                                  .Where(s => Option_.Options == s.Options && s.OptionID != Option_.OptionID)
                                                  .ToList();
                if (RepeatedOption.Count == 0)
                {

                    var optioninDB = await _db.Option.FindAsync(Option_.OptionID);
                    optioninDB.Options = Option_.Options;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("OptionIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Option already exist");
                    return Page();
                }
            }
            return RedirectToPage();
        }
    }
}
