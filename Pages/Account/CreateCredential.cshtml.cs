using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SchoolMaris.Pages.Account
{
    public class CreateCredentialModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Credentials Credentials_ { get; set; }
        public CreateCredentialModel(ApplicationDbContext db)
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
                var credentilsWithSameData = _db.Credentials
                                                  .Where(s => s.UserName == Credentials_.UserName && s.Password == Credentials_.Password && s.CredentialID != Credentials_.CredentialID)
                                                  .ToList();
                if (credentilsWithSameData.Count == 0)
                {
                    await _db.Credentials.AddAsync(Credentials_);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("LogIn");
                }
                else
                {
                    ModelState.AddModelError(" ", "Log In Credentials Already Exist");
                    return Page();
                }
            }
            return Page();
        }
    }
}
