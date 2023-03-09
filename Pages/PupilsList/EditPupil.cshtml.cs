using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaris.Pages.PupilsList
{
    public class EditPupilModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditPupilModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public PupilsProfile PupilsProfile_ { get; set; }
        public async Task OnGet(int id)
        {
            PupilsProfile_ = await _db.PupilsProfile.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            byte[] bytes = null;
            if (PupilsProfile_.ImageFile != null)
            {
                using (Stream fs = PupilsProfile_.ImageFile.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }
                }
                PupilsProfile_.PupilsImage = Convert.ToBase64String(bytes, 0, bytes.Length);
            }



            var PupilWithSameName = _db.PupilsProfile
                                                      .Where(s => s.FirstName == PupilsProfile_.FirstName && s.LastName == PupilsProfile_.LastName &&
                                                      s.DateOfBirth == PupilsProfile_.DateOfBirth && s.Age == PupilsProfile_.Age && s.Gender == PupilsProfile_.Gender &&
                                                      s.Address == PupilsProfile_.Address && s.PupilsProfileID != PupilsProfile_.PupilsProfileID)
                                                      .ToList();
            if (PupilWithSameName.Count == 0)
            {
                var PupilFromDb = await _db.PupilsProfile.FindAsync(PupilsProfile_.PupilsProfileID);
                PupilFromDb.PupilsImage = PupilsProfile_.PupilsImage;
                PupilFromDb.FirstName = PupilsProfile_.FirstName;
                PupilFromDb.LastName = PupilsProfile_.LastName;
                PupilFromDb.DateOfBirth = PupilsProfile_.DateOfBirth;
                PupilFromDb.Age = PupilsProfile_.Age;
                PupilFromDb.Gender = PupilsProfile_.Gender;
                PupilFromDb.Address = PupilsProfile_.Address;
                PupilFromDb.LastUpdatedDate = DateTime.Now;
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
