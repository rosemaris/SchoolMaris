using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMaris.Model;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web.Mvc;
using System.Runtime.InteropServices;

namespace SchoolMaris.Pages.EnrolmentProfileList
{
    public class EditEnrolmentModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public EnrolmentProfile EnrolmentProfile_ { get; set; }
        public EditEnrolmentModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            EnrolmentProfile_ = await _db.EnrolmentProfile.FindAsync(id);
            EnrolmentProfile_.LevelSubjectTeacherLists = _db.LevelSubjectTeacher.Include(x => x.LevelSubject.Level).Include(x => x.LevelSubject.Subject).ToList()
               .Select(levelsubjectteacher => new SelectListItem
               {
                   Value = levelsubjectteacher.LevelSubjectTeacherID.ToString(),
                   Text = levelsubjectteacher.LevelSubject.Level.Code + "-" + levelsubjectteacher.LevelSubject.Subject.Code.ToString()
               }).ToList();

            EnrolmentProfile_.PupilsLists = _db.PupilsProfile.ToList()
                .Select(pupil => new SelectListItem
                {
                    Value = pupil.PupilsProfileID.ToString(),
                    Text = pupil.FirstName + " " + pupil.LastName
                }).ToList();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var enrolleeWithSameData = _db.EnrolmentProfile
                                                 .Where(s => s.LevelSubjectTeacherID == EnrolmentProfile_.LevelSubjectTeacherID 
                                                 && s.PupilsProfileID == EnrolmentProfile_.PupilsProfileID 
                                                 && EnrolmentProfile_.EnrolmentProfileID != s.EnrolmentProfileID)
                                                 .ToList();
                if (enrolleeWithSameData.Count == 0)
                {
                    var enrolmentfromDb = await _db.EnrolmentProfile.FindAsync(EnrolmentProfile_.EnrolmentProfileID);
                    enrolmentfromDb.PupilsProfileID = EnrolmentProfile_.PupilsProfileID;
                    enrolmentfromDb.LevelSubjectTeacherID = EnrolmentProfile_.LevelSubjectTeacherID;
                    enrolmentfromDb.CreatedDate = DateTime.Now;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("EnrolmentIndex");
                }
                else
                {
                    ModelState.AddModelError(" ", "Enrollee's Profile already exist");
                    return Page();
                }

            }
            return RedirectToPage();
        }
    }
}
