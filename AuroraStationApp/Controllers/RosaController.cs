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
    public class RosaController : Controller
    {
        private readonly AuroraStationContext _context;

        public RosaController(AuroraStationContext context)
        {
            _context = context;
        }

        // GET: Giocatores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Giocatori.ToListAsync());
        }

        // GET: Giocatores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giocatore = await _context.Giocatori
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giocatore == null)
            {
                return NotFound();
            }

            return View(giocatore);
        }

        // GET: Giocatores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Giocatores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Ruolo,NumeroMaglia,Presenze,Goal,Assist,FotoUrl")] Giocatore giocatore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giocatore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giocatore);
        }

        // GET: Giocatores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giocatore = await _context.Giocatori.FindAsync(id);
            if (giocatore == null)
            {
                return NotFound();
            }
            return View(giocatore);
        }

        // POST: Giocatores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Ruolo,NumeroMaglia,Presenze,Goal,Assist,FotoUrl")] Giocatore giocatore)
        {
            if (id != giocatore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giocatore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiocatoreExists(giocatore.Id))
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
            return View(giocatore);
        }

        // GET: Giocatores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giocatore = await _context.Giocatori
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giocatore == null)
            {
                return NotFound();
            }

            return View(giocatore);
        }

        // POST: Giocatores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giocatore = await _context.Giocatori.FindAsync(id);
            if (giocatore != null)
            {
                _context.Giocatori.Remove(giocatore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiocatoreExists(int id)
        {
            return _context.Giocatori.Any(e => e.Id == id);
        }
    }
}
