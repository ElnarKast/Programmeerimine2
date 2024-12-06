using KooliProjekt.Data;
using KooliProjekt.Models;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly IBuildingsService _buildingsService;

        public BuildingsController(IBuildingsService buildingService)
        {
            _buildingsService = buildingService;
        }

        // GET: buildings
        public async Task<IActionResult> Index(int page = 1, BuildingsIndexModel model = null)
        {
            model = model ?? new BuildingsIndexModel();
            model.Data = await _buildingsService.List(page, 5, model.Search);

            return View(model);
        }

        // GET: buildings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _buildingsService.Get(id.Value);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // GET: buildings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: buildings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Building building)
        {
            if (ModelState.IsValid)
            {
                await _buildingsService.Save(building);
                return RedirectToAction(nameof(Index));
            }
            return View(building);
        }

        // GET: buildings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _buildingsService.Get(id.Value);
            if (building == null)
            {
                return NotFound();
            }
            return View(building);
        }

        // POST: buildings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Building building)
        {
            if (id != building.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _buildingsService.Save(building);
                return RedirectToAction(nameof(Index));
            }
            return View(building);
        }

        // GET: buildings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _buildingsService.Get(id.Value);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // POST: buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _buildingsService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}