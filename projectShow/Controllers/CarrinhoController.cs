using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projectShow.Models;

namespace projectShow.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly CarrinhoContext _context;

        public CarrinhoController(CarrinhoContext context)
        {
            _context = context;
        }        

        // GET: Carrinho
        public async Task<IActionResult> Index(int? id)
        {
            System.Console.WriteLine(id);
            var carrinhoContext = _context.Carrinho.Include(c => c.Ingresso);
            return View(await carrinhoContext.ToListAsync());
        }

        // GET: Carrinho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinho
                .Include(c => c.Ingresso)
                .FirstOrDefaultAsync(m => m.CarrinhoId == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // GET: Carrinho/Create
        public IActionResult Create()
        {
            ViewData["IngressoId"] = new SelectList(_context.Set<Ingresso>(), "IngressoId", "IngressoId");
            return View();
        }

        // POST: Carrinho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarrinhoId,IngressoId")] Carrinho carrinho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrinho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngressoId"] = new SelectList(_context.Set<Ingresso>(), "IngressoId", "IngressoId", carrinho.IngressoId);
            return View(carrinho);
        }

        // GET: Carrinho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinho.FindAsync(id);
            if (carrinho == null)
            {
                return NotFound();
            }
            ViewData["IngressoId"] = new SelectList(_context.Set<Ingresso>(), "IngressoId", "IngressoId", carrinho.IngressoId);
            return View(carrinho);
        }

        // POST: Carrinho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarrinhoId,IngressoId")] Carrinho carrinho)
        {
            if (id != carrinho.CarrinhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrinho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrinhoExists(carrinho.CarrinhoId))
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
            ViewData["IngressoId"] = new SelectList(_context.Set<Ingresso>(), "IngressoId", "IngressoId", carrinho.IngressoId);
            return View(carrinho);
        }

        // GET: Carrinho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinho
                .Include(c => c.Ingresso)
                .FirstOrDefaultAsync(m => m.CarrinhoId == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // POST: Carrinho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrinho = await _context.Carrinho.FindAsync(id);
            _context.Carrinho.Remove(carrinho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrinhoExists(int id)
        {
            return _context.Carrinho.Any(e => e.CarrinhoId == id);
        }

        public IActionResult Adicionar(int id)
        {
           System.Console.WriteLine(id);
           return RedirectToAction(nameof(Index), new { Id = id });
        }
    }
}
