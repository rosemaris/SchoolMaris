using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Linq;
using System.Threading.Tasks;
using System;


namespace SchoolMaris.Pages.Account
{
    public class LOGINModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Credentials Credentials_ { get; set; }  = new Credentials();
        public LOGINModel(ApplicationDbContext db)
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

                    ModelState.AddModelError(" ", "Invalid User Name or Password Credentials");
                    return Page();
                }
                else
                {
                    await _db.Credentials.AddAsync(Credentials_);
                    return RedirectToPage("/CurriculumPages/Index");
                }
            }
            return Page();
        }
    }
}
