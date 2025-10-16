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

        public async Task<IActionResult> Index()
        {
            var productos = await _service.GetAllAsync();
            return View(productos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HistoriaClinica historiaclinica)
        {
            if (!ModelState.IsValid)
                return View(historiaclinica);

            await _service.AddAsync(historiaclinica);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var historiaclinica = await _service.GetByIdAsync(id);
            if (historiaclinica == null) return NotFound();
            return View(historiaclinica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HistoriaClinica historiaclinica)
        {
            if (!ModelState.IsValid)
                return View(historiaclinica);

            await _service.UpdateAsync(historiaclinica);
            return RedirectToAction(nameof(Index));
        }

            // GET: HistoriaClinica/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            /*

             var producto = await _service.GetByIdAsync(id);
             if (producto == null) return NotFound();
             return View(producto);
            */
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
