using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.Account
{
    public class LogInModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Credentials Credentials_ { get; set; }
        public LogInModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task OnGet(int id)
        {
            Credentials_ = await _db.Credentials.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var inputCredential = await _db.Credentials.FindAsync(id);
                if (inputCredential == null)
                {
                    ModelState.AddModelError(" ", "Credential Cannot Be Found");
                    return Page();
                }
                return RedirectToPage("/Index");
            }
            return RedirectToPage("/Index");
        }

    }
}
