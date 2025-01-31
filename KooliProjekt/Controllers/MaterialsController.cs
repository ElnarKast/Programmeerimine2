using KooliProjekt.Data;
using KooliProjekt.Models;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly MaterialsService _materialsService;
        private IMaterialsService @object;

        public MaterialsController(MaterialsService materialService)
        {
            _materialsService = materialService;
        }

        public MaterialsController(IMaterialsService @object)
        {
            this.@object = @object;
        }

        // GET: materials
        public async Task<IActionResult> Index(int page = 1, MaterialsIndexModel model = null)
        {
            model = model ?? new MaterialsIndexModel();
            model.Data = await _materialsService.List(page, 5, model.Search);

            return View(model);
        }

        // GET: materials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _materialsService.Get(id.Value);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: materials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Material material)
        {
            if (ModelState.IsValid)
            {
                await _materialsService.Save(material);
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: materials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _materialsService.Get(id.Value);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        // POST: materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Material material)
        {
            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _materialsService.Save(material);
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: materials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _materialsService.Get(id.Value);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _materialsService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}