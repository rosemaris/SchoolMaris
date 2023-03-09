using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMaris.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.PupilsList
{
    public class PupilsIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public PupilsIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<PupilsProfile> PupilsProfile_ { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? PSearchString { get; set; }
        public SelectList? Codes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PCode { get; set; }
        public async Task OnGetAsync()
        {
            if (_db.PupilsProfile != null)
            {
                IQueryable<string> codeQuery = from m in _db.PupilsProfile
                                               orderby m.Gender
                                               select m.Gender;
                var pupil = from m in _db.PupilsProfile
                              select m;
                if (!string.IsNullOrEmpty(PSearchString))
                {
                    pupil = pupil.Where(s => s.LastName.Contains(PSearchString));
                }

                if (!string.IsNullOrEmpty(PCode))
                {
                    pupil = pupil.Where(x => x.Gender == PCode);
                }
                Codes = new SelectList(await codeQuery.Distinct().ToListAsync());
                PupilsProfile_ = await pupil.ToListAsync();
            }

        }


        public async Task<IActionResult> OnPostDelete(int id)
        {
            var pupil = await _db.PupilsProfile.FindAsync(id);
            if (pupil == null)
            {
                return NotFound();
            }

            _db.PupilsProfile.Remove(pupil);
            await _db.SaveChangesAsync();
            return RedirectToPage("PupilsIndex");
        }
    }
}
