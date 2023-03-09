using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using SchoolMaris.Model;
using System;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.PupilsList
{
    public class CreatePupilModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public PupilsProfile PupilProfile_ { get; set; }

        public CreatePupilModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            byte[] bytes = null;
            if (PupilProfile_.ImageFile != null)
            {
                using (Stream fs = PupilProfile_.ImageFile.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }
                }
                PupilProfile_.PupilsImage = Convert.ToBase64String(bytes, 0, bytes.Length);
            }

            var PupilWithSameData = _db.PupilsProfile
                                       .Where(s => s.FirstName == PupilProfile_.FirstName && s.LastName == PupilProfile_.LastName)
                                       .ToList();

            if (PupilWithSameData.Count == 0)
            {

                PupilProfile_.CreatedDate = DateTime.Now;
                await _db.PupilsProfile.AddAsync(PupilProfile_);
                await _db.SaveChangesAsync();
                return RedirectToPage("PupilsIndex");
            }
            else
            {
                ModelState.AddModelError(" ", "Pupils Data already exist");
                return Page();
            }
        }


    }
}
