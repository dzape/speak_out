using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using speak_out.Data;
using speak_out.Models;

namespace speak_out.Controllers
{
    public class VolunteersController : Controller
    {
        private readonly SpeakOutContext _context;

        public VolunteersController(SpeakOutContext context)
        {
            _context = context;
        }

        // GET: Volunteers

            /// <summary>
            ///  kshdjaskjdksajdksajdkasjdkasjdkjsad
            /// </summary>
            /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var speakOutContext = _context.Volunteers.Include(v => v.User);
            return View(await speakOutContext.ToListAsync());
        }

        // GET: Volunteers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteers = await _context.Volunteers
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.VolunteerId == id);
            if (volunteers == null)
            {
                return NotFound();
            }

            return View(volunteers);
        }

        // GET: Volunteers/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Volunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VolunteerId,UserId,VolunteerName,VolunteerSurname,VolunteerUserName,VolunteerEmail,VolunteerPassword,VolunteerPhoneNumber")] Volunteers volunteers)
        {
            if (ModelState.IsValid)
            {
                volunteers.VolunteerPassword = Crypto.Hash(volunteers.VolunteerPassword);

                _context.Add(volunteers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", volunteers.UserId);
            return View(volunteers);
        }

        // GET: Volunteers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteers = await _context.Volunteers.FindAsync(id);
            if (volunteers == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", volunteers.UserId);
            return View(volunteers);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VolunteerId,UserId,VolunteerName,VolunteerSurname,VolunteerUserName,VolunteerEmail,VolunteerPassword,VolunteerPhoneNumber")] Volunteers volunteers)
        {
            if (id != volunteers.VolunteerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volunteers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolunteersExists(volunteers.VolunteerId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", volunteers.UserId);
            return View(volunteers);
        }

        // GET: Volunteers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteers = await _context.Volunteers
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.VolunteerId == id);
            if (volunteers == null)
            {
                return NotFound();
            }

            return View(volunteers);
        }

        // POST: Volunteers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volunteers = await _context.Volunteers.FindAsync(id);
            _context.Volunteers.Remove(volunteers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolunteersExists(int id)
        {
            return _context.Volunteers.Any(e => e.VolunteerId == id);
        }
    }
}
