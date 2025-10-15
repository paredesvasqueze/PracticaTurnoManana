using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Web.Controllers
{

        public class HistoriaClinicaController : Controller
        {
            private readonly IHistoriaClinicaService _service;

            public HistoriaClinicaController(IHistoriaClinicaService service)
            {
                _service = service;
            }

            // GET: HistoriaClinica
            public async Task<IActionResult> Index()
            {
                var historias = await _service.GetAllAsync();
                return View(historias);
            }

            // GET: HistoriaClinica/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: HistoriaClinica/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(HistoriaClinica historiaClinica)
            {
                if (!ModelState.IsValid)
                    return View(historiaClinica);

                await _service.AddAsync(historiaClinica);
                return RedirectToAction(nameof(Index));
            }

            // GET: HistoriaClinica/Edit/5
            public async Task<IActionResult> Edit(int id)
            {
                var historia = await _service.GetByIdAsync(id);
                if (historia == null) return NotFound();

                return View(historia);
            }

            // POST: HistoriaClinica/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(HistoriaClinica historiaClinica)
            {
                if (!ModelState.IsValid)
                    return View(historiaClinica);

                await _service.UpdateAsync(historiaClinica);
                return RedirectToAction(nameof(Index));
            }

            // GET: HistoriaClinica/Delete/5
            public async Task<IActionResult> Delete(int id)
            {
                var historia = await _service.GetByIdAsync(id);
                if (historia == null) return NotFound();

                return View(historia);
            }

            // POST: HistoriaClinica/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
}
