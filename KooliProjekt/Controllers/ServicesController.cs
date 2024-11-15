using KooliProjekt.Data;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.Controllers
{
    public class servicesController : Controller
    {
        private readonly IServicesService _serviceService;

        public servicesController(IServicesService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: services
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _serviceService.List(page, 5);

            return View(data);
        }

        // GET: services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _serviceService.Get(id.Value);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Service service)
        {
            if (ModelState.IsValid)
            {
                await _serviceService.Save(service);
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _serviceService.Get(id.Value);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _serviceService.Save(service);
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _serviceService.Get(id.Value);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serviceService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}