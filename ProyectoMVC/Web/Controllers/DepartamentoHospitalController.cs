using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class DepartamentoHospitalController : Controller
    {
        private readonly IDepartamentoHospitalService _service;

        public DepartamentoHospitalController(IDepartamentoHospitalService service)
        {
            // El servicio se inyecta
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var departamentos = await _service.GetAllAsync();
            return View(departamentos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartamentoHospital departamento)
        {
            // Usamos la validación de Data Annotations
            if (!ModelState.IsValid)
                return View(departamento);

            await _service.AddAsync(departamento);
            // Redirige al listado después de crear
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var departamento = await _service.GetByIdAsync(id);
            if (departamento == null) return NotFound();
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartamentoHospital departamento)
        {
            if (!ModelState.IsValid)
                return View(departamento);

            await _service.UpdateAsync(departamento);
            return RedirectToAction(nameof(Index));
        }

        // Acción de confirmación de borrado
        public async Task<IActionResult> Delete(int id)
        {
            // var departamento = await _service.GetByIdAsync(id);
            // if (departamento == null) return NotFound();
            // Retornamos la vista de confirmación (si la tienes) o la vista de borrado directo.
            // return View(departamento);
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
