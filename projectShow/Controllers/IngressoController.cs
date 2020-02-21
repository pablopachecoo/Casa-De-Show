using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projectShow.Models;

namespace projectShow.Controllers
{
    public class IngressoController : Controller
    {
        private readonly IngressoContext _context;

        public IngressoController(IngressoContext context)
        {
            _context = context;
        }

        // GET: Ingresso
        public async Task<IActionResult> Index()
        {            
            var ingressoContext = _context.Ingresso.Include(i => i.Eventos);
            return View(await ingressoContext.ToListAsync());
        }

        // GET: Ingresso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingresso
                .Include(i => i.Eventos)
                .FirstOrDefaultAsync(m => m.IngressoId == id);
            if (ingresso == null)
            {
                return NotFound();
            }

            return View(ingresso);
        }

        // GET: Ingresso/Create
        public IActionResult Create(int id, string nome)
        {
            ViewBag.nome = nome;
            ViewBag.id = id;
            ViewData["EventosId"] = new SelectList(_context.Set<Eventos>(), "EventosId", "EventosId");
            return View();
        }

        // POST: Ingresso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, string nome, [Bind("IngressoId,EventosId")] Ingresso ingresso)
        {
            ViewBag.nome = nome;
            ViewBag.id = id;
            if (ModelState.IsValid)
            {
                _context.Add(ingresso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventosId"] = new SelectList(_context.Set<Eventos>(), "EventosId", "EventosId", ingresso.EventosId);
            return View(ingresso);
        }

        // GET: Ingresso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingresso.FindAsync(id);
            if (ingresso == null)
            {
                return NotFound();
            }
            ViewData["EventosId"] = new SelectList(_context.Set<Eventos>(), "EventosId", "EventosId", ingresso.EventosId);
            return View(ingresso);
        }

        // POST: Ingresso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngressoId,EventosId")] Ingresso ingresso)
        {
            if (id != ingresso.IngressoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingresso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngressoExists(ingresso.IngressoId))
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
            ViewData["EventosId"] = new SelectList(_context.Set<Eventos>(), "EventosId", "EventosId", ingresso.EventosId);
            return View(ingresso);
        }

        // GET: Ingresso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingresso
                .Include(i => i.Eventos)
                .FirstOrDefaultAsync(m => m.IngressoId == id);
            if (ingresso == null)
            {
                return NotFound();
            }

            return View(ingresso);
        }

        // POST: Ingresso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingresso = await _context.Ingresso.FindAsync(id);
            _context.Ingresso.Remove(ingresso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngressoExists(int id)
        {
            return _context.Ingresso.Any(e => e.IngressoId == id);
        }
    }
}
