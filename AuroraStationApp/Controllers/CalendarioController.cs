using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuroraStationApp.Models;

namespace AuroraStationApp.Controllers
{
    public class CalendarioController : Controller
    {
        private readonly AuroraStationContext _context;

        public CalendarioController(AuroraStationContext context)
        {
            _context = context;
        }

        // GET: Partitas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partite.ToListAsync());
        }

        // GET: Partitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partita = await _context.Partite
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partita == null)
            {
                return NotFound();
            }

            return View(partita);
        }

        // GET: Partitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataOra,Avversario,Luogo,GoalFatti,GoalSubiti,PartitaConclusa")] Partita partita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partita);
        }

        // GET: Partitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partita = await _context.Partite.FindAsync(id);
            if (partita == null)
            {
                return NotFound();
            }
            return View(partita);
        }

        // POST: Partitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataOra,Avversario,Luogo,GoalFatti,GoalSubiti,PartitaConclusa")] Partita partita)
        {
            if (id != partita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartitaExists(partita.Id))
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
            return View(partita);
        }

        // GET: Partitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partita = await _context.Partite
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partita == null)
            {
                return NotFound();
            }

            return View(partita);
        }

        // POST: Partitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partita = await _context.Partite.FindAsync(id);
            if (partita != null)
            {
                _context.Partite.Remove(partita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartitaExists(int id)
        {
            return _context.Partite.Any(e => e.Id == id);
        }
    }
}
