using KooliProjekt.Data;
using KooliProjekt.Models;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService ServiceService)
        {
            _servicesService = ServiceService;
        }

        // GET: services
        public async Task<IActionResult> Index(int page = 1, ServicesIndexModel model = null)
        {
            model = model ?? new ServicesIndexModel();
            model.Data = await _servicesService.List(page, 5, model.Search);

            return View(model);
        }

        // GET: services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _servicesService.Get(id.Value);
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
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service)
        {
            if (ModelState.IsValid)
            {
                await _servicesService.Save(service);
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

            var service = await _servicesService.Get(id.Value);
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
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _servicesService.Save(service);
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

            var service = await _servicesService.Get(id.Value);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: services/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _servicesService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}