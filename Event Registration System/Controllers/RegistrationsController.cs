using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Event_Registration_System.Data;
using Event_Registration_System.Models;
using MVCAuth.Services;


namespace Event_Registration_System.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly EventContext _context;
        private readonly MailjetService _emailServices;

        public RegistrationsController(EventContext context, MailjetService emailServices)
        {
            _context = context;
            _emailServices = emailServices;
        }

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
            var eventContext = _context.Registrations.Include(r => r.Event);
            return View(await eventContext.ToListAsync());
        }

        // GET: Registrations/Create
        public IActionResult Create()
        {
            // Change "Title" to display the event titles in the dropdown
            ViewBag.EventId = new SelectList(_context.Events, "EventId", "Title");
            return View();
        }

        // POST: Registrations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistrationId,ParticipantName,Email,EventId")] Registration registration)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(registration);
                await _context.SaveChangesAsync();

                // Send confirmation email
                var subject = "Registration Confirmation";
                var textPart = "Welcome to our event! Your registration has been confirmed.";
                var htmlPart = "<h3>Welcome to our event!</h3><p>Your registration has been confirmed.</p>";
                await _emailServices.SendEmail(registration.Email, registration.ParticipantName, subject, textPart, htmlPart);

                return RedirectToAction(nameof(Index));
            //}

            // If ModelState is invalid, ensure the dropdown is still populated with the correct titles
            ViewBag.EventId = new SelectList(_context.Events, "EventId", "Title", registration.EventId);
            return View(registration);
        }


        // GET: Registrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Description", registration.EventId);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistrationId,ParticipantName,Email,EventId")] Registration registration)
        {
            if (id != registration.RegistrationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.RegistrationId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Description", registration.EventId);
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .Include(r => r.Event)
                .FirstOrDefaultAsync(m => m.RegistrationId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registrations.Any(e => e.RegistrationId == id);
        }
    }
}
