using KooliProjekt.Data;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.Controllers
{
    public class PanelsController : Controller
    {
        private readonly IPanelsService _panelService;

        public PanelsController(IPanelsService panelService)
        {
            _panelService = panelService;
        }

        // GET: panels
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _panelService.List(page, 5);

            return View(data);
        }

        // GET: panels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panel = await _panelService.Get(id.Value);
            if (panel == null)
            {
                return NotFound();
            }

            return View(panel);
        }

        // GET: panels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: panels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Panel panel)
        {
            if (ModelState.IsValid)
            {
                await _panelService.Save(panel);
                return RedirectToAction(nameof(Index));
            }
            return View(panel);
        }

        // GET: panels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panel = await _panelService.Get(id.Value);
            if (panel == null)
            {
                return NotFound();
            }
            return View(panel);
        }

        // POST: panels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Panel panel)
        {
            if (id != panel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _panelService.Save(panel);
                return RedirectToAction(nameof(Index));
            }
            return View(panel);
        }

        // GET: panels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panel = await _panelService.Get(id.Value);
            if (panel == null)
            {
                return NotFound();
            }

            return View(panel);
        }

        // POST: panels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _panelService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}