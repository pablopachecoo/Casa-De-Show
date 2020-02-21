using System;
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
    public class CasasDeShowController : Controller
    {
        private readonly CasasDeShowContext _context;

        public CasasDeShowController(CasasDeShowContext context)
        {
            _context = context;
        }

        // GET: CasasDeShow
        public async Task<IActionResult> Index()
        {
            return View(await _context.CasasDeShow.ToListAsync());
        }

        // GET: CasasDeShow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casasDeShow = await _context.CasasDeShow
                .FirstOrDefaultAsync(m => m.CasasDeShowId == id);
            if (casasDeShow == null)
            {
                return NotFound();
            }

            return View(casasDeShow);
        }

        // GET: CasasDeShow/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasasDeShow/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasasDeShowId,Endereco,NomeDaCasa")] CasasDeShow casasDeShow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casasDeShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casasDeShow);
        }

        // GET: CasasDeShow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casasDeShow = await _context.CasasDeShow.FindAsync(id);
            if (casasDeShow == null)
            {
                return NotFound();
            }
            return View(casasDeShow);
        }

        // POST: CasasDeShow/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CasasDeShowId,Endereco,NomeDaCasa")] CasasDeShow casasDeShow)
        {
            if (id != casasDeShow.CasasDeShowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casasDeShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasasDeShowExists(casasDeShow.CasasDeShowId))
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
            return View(casasDeShow);
        }

        // GET: CasasDeShow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casasDeShow = await _context.CasasDeShow
                .FirstOrDefaultAsync(m => m.CasasDeShowId == id);
            if (casasDeShow == null)
            {
                return NotFound();
            }

            return View(casasDeShow);
        }

        // POST: CasasDeShow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casasDeShow = await _context.CasasDeShow.FindAsync(id);
            _context.CasasDeShow.Remove(casasDeShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasasDeShowExists(int id)
        {
            return _context.CasasDeShow.Any(e => e.CasasDeShowId == id);
        }
    }
}
