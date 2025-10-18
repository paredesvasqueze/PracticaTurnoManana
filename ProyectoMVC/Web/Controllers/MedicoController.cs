using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Web.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoService _service;

        public MedicoController(IMedicoService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var medicos = await _service.GetAllAsync();
            return View(medicos);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medico medico)
        {
            if (!ModelState.IsValid)
                return View(medico);

            await _service.AddAsync(medico);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var medico = await _service.GetByIdAsync(id);
            if (medico == null)
                return NotFound();

            return View(medico);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Medico medico)
        {
            if (!ModelState.IsValid)
                return View(medico);

            await _service.UpdateAsync(medico);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
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
