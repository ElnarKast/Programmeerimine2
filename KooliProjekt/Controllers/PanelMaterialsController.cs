using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;

namespace KooliProjekt.Controllers
{
    public class PanelMaterialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PanelMaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PanelMaterials
        public async Task<IActionResult> Index(int page = 1)
        {
            var applicationDbContext = _context.PanelMaterial.Include(p => p.Material).Include(p => p.Panel);
            return View(await applicationDbContext.GetPagedAsync(page, 2));
        }

        // GET: PanelMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelMaterial = await _context.PanelMaterial
                .Include(p => p.Material)
                .Include(p => p.Panel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panelMaterial == null)
            {
                return NotFound();
            }

            return View(panelMaterial);
        }

        // GET: PanelMaterials/Create
        public IActionResult Create()
        {
            ViewData["MaterialId"] = new SelectList(_context.Material, "Id", "Id");
            ViewData["PanelId"] = new SelectList(_context.Panel, "Id", "Id");
            return View();
        }

        // POST: PanelMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,MaterialId,PanelId,UnitPrice,TotalPrice")] PanelMaterial panelMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(panelMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaterialId"] = new SelectList(_context.Material, "Id", "Id", panelMaterial.MaterialId);
            ViewData["PanelId"] = new SelectList(_context.Panel, "Id", "Id", panelMaterial.PanelId);
            return View(panelMaterial);
        }

        // GET: PanelMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelMaterial = await _context.PanelMaterial.FindAsync(id);
            if (panelMaterial == null)
            {
                return NotFound();
            }
            ViewData["MaterialId"] = new SelectList(_context.Material, "Id", "Id", panelMaterial.MaterialId);
            ViewData["PanelId"] = new SelectList(_context.Panel, "Id", "Id", panelMaterial.PanelId);
            return View(panelMaterial);
        }

        // POST: PanelMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,MaterialId,PanelId,UnitPrice,TotalPrice")] PanelMaterial panelMaterial)
        {
            if (id != panelMaterial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(panelMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PanelMaterialExists(panelMaterial.Id))
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
            ViewData["MaterialId"] = new SelectList(_context.Material, "Id", "Id", panelMaterial.MaterialId);
            ViewData["PanelId"] = new SelectList(_context.Panel, "Id", "Id", panelMaterial.PanelId);
            return View(panelMaterial);
        }

        // GET: PanelMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelMaterial = await _context.PanelMaterial
                .Include(p => p.Material)
                .Include(p => p.Panel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panelMaterial == null)
            {
                return NotFound();
            }

            return View(panelMaterial);
        }

        // POST: PanelMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var panelMaterial = await _context.PanelMaterial.FindAsync(id);
            if (panelMaterial != null)
            {
                _context.PanelMaterial.Remove(panelMaterial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PanelMaterialExists(int id)
        {
            return _context.PanelMaterial.Any(e => e.Id == id);
        }
    }
}
