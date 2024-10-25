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
    public class BuildingPanelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuildingPanelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BuildingPanels
        public async Task<IActionResult> Index(int page = 1)
        {
            var applicationDbContext = _context.BuildingPanels.Include(b => b.Building).Include(b => b.Panel);
            return View(await applicationDbContext.GetPagedAsync(page, 2));
        }

        // GET: BuildingPanels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingPanels = await _context.BuildingPanels
                .Include(b => b.Building)
                .Include(b => b.Panel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingPanels == null)
            {
                return NotFound();
            }

            return View(buildingPanels);
        }

        // GET: BuildingPanels/Create
        public IActionResult Create()
        {
            ViewData["BuildingId"] = new SelectList(_context.Building, "Id", "Id");
            ViewData["PanelId"] = new SelectList(_context.Panel, "Id", "Id");
            return View();
        }

        // POST: BuildingPanels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,BuildingId,PanelId")] BuildingPanels buildingPanels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingPanels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingId"] = new SelectList(_context.Building, "Id", "Id", buildingPanels.BuildingId);
            ViewData["PanelId"] = new SelectList(_context.Panel, "Id", "Id", buildingPanels.PanelId);
            return View(buildingPanels);
        }

        // GET: BuildingPanels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingPanels = await _context.BuildingPanels.FindAsync(id);
            if (buildingPanels == null)
            {
                return NotFound();
            }
            ViewData["BuildingId"] = new SelectList(_context.Building, "Id", "Id", buildingPanels.BuildingId);
            ViewData["PanelId"] = new SelectList(_context.Panel, "Id", "Id", buildingPanels.PanelId);
            return View(buildingPanels);
        }

        // POST: BuildingPanels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,BuildingId,PanelId")] BuildingPanels buildingPanels)
        {
            if (id != buildingPanels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingPanels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingPanelsExists(buildingPanels.Id))
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
            ViewData["BuildingId"] = new SelectList(_context.Building, "Id", "Id", buildingPanels.BuildingId);
            ViewData["PanelId"] = new SelectList(_context.Panel, "Id", "Id", buildingPanels.PanelId);
            return View(buildingPanels);
        }

        // GET: BuildingPanels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingPanels = await _context.BuildingPanels
                .Include(b => b.Building)
                .Include(b => b.Panel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingPanels == null)
            {
                return NotFound();
            }

            return View(buildingPanels);
        }

        // POST: BuildingPanels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingPanels = await _context.BuildingPanels.FindAsync(id);
            if (buildingPanels != null)
            {
                _context.BuildingPanels.Remove(buildingPanels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingPanelsExists(int id)
        {
            return _context.BuildingPanels.Any(e => e.Id == id);
        }
    }
}
