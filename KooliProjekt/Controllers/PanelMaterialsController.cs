using KooliProjekt.Data;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.Controllers
{
    public class PanelMaterialsController : Controller
    {
        private readonly IPanelMaterialsService _panelmaterialsService;

        public PanelMaterialsController(IPanelMaterialsService PanelMaterialService)
        {
            _panelmaterialsService = PanelMaterialService;
        }

        // GET: panels
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _panelmaterialsService.List(page, 5);

            return View(data);
        }

        // GET: panels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PanelMaterial = await _panelmaterialsService.Get(id.Value);
            if (PanelMaterial == null)
            {
                return NotFound();
            }

            return View(PanelMaterial);
        }

        // GET: panelMaterials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: panelMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PanelMaterial PanelMaterial)
        {
            if (ModelState.IsValid)
            {
                await _panelmaterialsService.Save(PanelMaterial);
                return RedirectToAction(nameof(Index));
            }
            return View(PanelMaterial);
        }

        // GET: panelMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PanelMaterial = await _panelmaterialsService.Get(id.Value);
            if (PanelMaterial == null)
            {
                return NotFound();
            }
            return View(PanelMaterial);
        }

        // POST: panelMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] PanelMaterial PanelMaterial)
        {
            if (id != PanelMaterial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _panelmaterialsService.Save(PanelMaterial);
                return RedirectToAction(nameof(Index));
            }
            return View(PanelMaterial);
        }

        // GET: panelMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PanelMaterial = await _panelmaterialsService.Get(id.Value);
            if (PanelMaterial == null)
            {
                return NotFound();
            }

            return View(PanelMaterial);
        }

        // POST: panelMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _panelmaterialsService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}