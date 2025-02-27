using KooliProjekt.Data;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.Controllers
{
    public class BuildingPanelsController : Controller
    {
        private readonly IBuildingPanelsService _BuildingPanelService;

        public BuildingPanelsController(IBuildingPanelsService BuildingPanelService)
        {
            _BuildingPanelService = BuildingPanelService;
        }

        // GET: BuildingPanels
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _BuildingPanelService.List(page, 5);

            return View(data);
        }

        // GET: BuildingPanels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BuildingPanel = await _BuildingPanelService.Get(id.Value);
            if (BuildingPanel == null)
            {
                return NotFound();
            }

            return View(BuildingPanel);
        }

        // GET: BuildingPanels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuildingPanels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] BuildingPanels BuildingPanel)
        {
            if (ModelState.IsValid)
            {
                await _BuildingPanelService.Save(BuildingPanel);
                return RedirectToAction(nameof(Index));
            }
            return View(BuildingPanel);
        }

        // GET: BuildingPanels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BuildingPanel = await _BuildingPanelService.Get(id.Value);
            if (BuildingPanel == null)
            {
                return NotFound();
            }
            return View(BuildingPanel);
        }

        // POST: BuildingPanels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] BuildingPanels BuildingPanel)
        {
            if (id != BuildingPanel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _BuildingPanelService.Save(BuildingPanel);
                return RedirectToAction(nameof(Index));
            }
            return View(BuildingPanel);
        }

        // GET: BuildingPanels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BuildingPanel = await _BuildingPanelService.Get(id.Value);
            if (BuildingPanel == null)
            {
                return NotFound();
            }

            return View(BuildingPanel);
        }

        // POST: BuildingPanels/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _BuildingPanelService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}