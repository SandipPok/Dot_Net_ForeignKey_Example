using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MultipleConnection.Data;
using MultipleConnection.Models;

namespace MultipleConnection.Controllers
{
    public class ResumeController : Controller
    {
        public readonly AppDbContext _context;
        public ResumeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Applicant> applicants;

            applicants = _context.Applicants.ToList();

            return View(applicants);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();

            applicant.Experiences.Add(new Experience() { /*ExperienceId = 1*/ });
            /*applicant.Experiences.Add(new Experience() { ExperienceId = 2 });
            applicant.Experiences.Add(new Experience() { ExperienceId = 3 });*/

            return View(applicant);
        }
        [HttpPost]
        public IActionResult Create(Applicant applicant)
        {
            _context.Add(applicant);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Applicants == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants.Include(e => e.Experiences).Where(a => a.Id == id).SingleOrDefaultAsync();

            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Applicants == null)
            {
                return NotFound();
            }

            /*var applicant = await _context.Applicants.FindAsync(id);*/
            var applicant = await _context.Applicants.Include(e => e.Experiences).Include(e => e.Experiences).Where(i => i.Id == id).FirstOrDefaultAsync();

            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id","Name","Gender","Age","Qualification","TotalExperience", "Experiences")] Applicant applicant)
        {
            if (id != applicant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicant);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!ApplicantExists(applicant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicant);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Applicants == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants.FindAsync(id);

            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Applicants == null)
            {
                return Problem("Entity set 'MultipleConnection.AppDbContext' is null.");
            }
            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant != null)
            {
                _context.Applicants.Remove(applicant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ApplicantExists(int id)
        {
            return _context.Applicants.Any(e => e.Id == id);
        }
    }
}
