using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projectShow.Data;
using projectShow.Models;

namespace projectShow.Controllers
{
    public class EventosController : Controller
    {
        private readonly EventosContext _context;
        private readonly CasasDeShowContext _cacontext;
        private readonly IngressoContext _ingcontext;

        public EventosController(EventosContext context, CasasDeShowContext cacontext, IngressoContext ingcontext)
        {
            _context = context;
            _cacontext = cacontext;
            _ingcontext = ingcontext;
        }
        // GET: Eventos
        public async Task<IActionResult> Index()
        { 
            ViewBag.casa = _cacontext.CasasDeShow.ToList();
            var eventosContext = _context.Eventos.Include(e => e.CasasDeShow);
            return View(await eventosContext.ToListAsync());
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventos = await _context.Eventos
                .Include(e => e.CasasDeShow)
                .FirstOrDefaultAsync(m => m.EventosId == id);
            if (eventos == null)
            {
                return NotFound();
            }

            return View(eventos);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            ViewData["CasasDeShowId"] = new SelectList(_context.Set<CasasDeShow>(), "CasasDeShowId", "CasasDeShowId");
            ViewBag.casa = _cacontext.CasasDeShow.ToList();
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventosId,NomeDoEvento,CapacidadeDoevento,QuantidadeDeIngressos,DataDoEvento,ValorDoIngresso,GeneroDoEvento,CasasDeShowId")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                ViewBag.casa = _cacontext.CasasDeShow.ToList();
                _context.Add(eventos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CasasDeShowId"] = new SelectList(_context.Set<CasasDeShow>(), "CasasDeShowId", "CasasDeShowId", eventos.CasasDeShowId);
            return View(eventos);
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventos = await _context.Eventos.FindAsync(id);
            if (eventos == null)
            {
                return NotFound();
            }
            ViewData["CasasDeShowId"] = new SelectList(_context.Set<CasasDeShow>(), "CasasDeShowId", "CasasDeShowId", eventos.CasasDeShowId);
            return View(eventos);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventosId,NomeDoEvento,CapacidadeDoevento,QuantidadeDeIngressos,DataDoEvento,ValorDoIngresso,GeneroDoEvento,CasasDeShowId")] Eventos eventos)
        {
            if (id != eventos.EventosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventosExists(eventos.EventosId))
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
            ViewData["CasasDeShowId"] = new SelectList(_context.Set<CasasDeShow>(), "CasasDeShowId", "CasasDeShowId", eventos.CasasDeShowId);
            return View(eventos);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventos = await _context.Eventos
                .Include(e => e.CasasDeShow)
                .FirstOrDefaultAsync(m => m.EventosId == id);
            if (eventos == null)
            {
                return NotFound();
            }

            return View(eventos);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventos = await _context.Eventos.FindAsync(id); 
            _context.Eventos.Remove(eventos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool EventosExists(int id)
        {
            return _context.Eventos.Any(e => e.EventosId == id);
        }
        public IActionResult Comprar(int id, string nome)
        {
            return RedirectToAction("Create", "Ingresso", new { Id = id, Nome = nome});
        }
    }
}