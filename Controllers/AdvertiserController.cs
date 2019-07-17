using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raspertise.Data;
using Raspertise.Models;

namespace Raspertise.Controllers
{
    public class AdvertiserController : Controller
    {
        private readonly RaspertiseContext _context;

        public AdvertiserController(RaspertiseContext context)
        {
            _context = context;
        }

        // GET: Advertiser
        public async Task<IActionResult> Index()
        {
            return View(await _context.Advertisers.ToListAsync());
        }

        // GET: Advertiser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertiser = await _context.Advertisers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertiser == null)
            {
                return NotFound();
            }

            return View(advertiser);
        }

        // GET: Advertiser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Advertiser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,AmountEarned")] Advertiser advertiser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advertiser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advertiser);
        }

        // GET: Advertiser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertiser = await _context.Advertisers.FindAsync(id);
            if (advertiser == null)
            {
                return NotFound();
            }
            return View(advertiser);
        }

        // POST: Advertiser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone,AmountEarned")] Advertiser advertiser)
        {
            if (id != advertiser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advertiser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertiserExists(advertiser.Id))
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
            return View(advertiser);
        }

        // GET: Advertiser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertiser = await _context.Advertisers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertiser == null)
            {
                return NotFound();
            }

            return View(advertiser);
        }

        // POST: Advertiser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertiser = await _context.Advertisers.FindAsync(id);
            _context.Advertisers.Remove(advertiser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertiserExists(int id)
        {
            return _context.Advertisers.Any(e => e.Id == id);
        }
    }
}
