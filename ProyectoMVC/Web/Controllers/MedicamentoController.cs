using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class MedicamentoController : Controller
    {
        private readonly IMedicamentoService _service;

        public MedicamentoController(IMedicamentoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var medicamentos = await _service.GetAllAsync();
            return View(medicamentos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medicamento medicamento)
        {
            if (!ModelState.IsValid)
                return View(medicamento);

            await _service.AddAsync(medicamento);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var medicamento = await _service.GetByIdAsync(id);
            if (medicamento == null) return NotFound();
            return View(medicamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Medicamento medicamento)
        {
            if (!ModelState.IsValid)
                return View(medicamento);

            await _service.UpdateAsync(medicamento);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            /*
            var medicamento = await _service.GetByIdAsync(id);
            if (medicamento == null) return NotFound();
            return View(medicamento);
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

