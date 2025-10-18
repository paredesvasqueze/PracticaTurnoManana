using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Web.Controllers
{
    public class MedicamentoAjaxController : Controller
    {
        private readonly IMedicamentoService _service;

        public MedicamentoAjaxController(IMedicamentoService service)
        {
            _service = service;
        }
                   
        public async Task<IActionResult> Index()
        {
            var medicamentos = await _service.GetAllAsync();
            return View(medicamentos);
        }

        [HttpGet]
        public IActionResult Form(int? id)
        {
            if (id == null || id == 0)
                return PartialView("_FormularioMedicamento", new Medicamento());
            else
            {
                var medicamento = _service.GetByIdAsync(id.Value).Result;
                return PartialView("_FormularioMedicamento", medicamento);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Medicamento medicamento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var cMensaje = "";
                    foreach (var item in ModelState)
                    {
                        var field = item.Key;
                        var errors = item.Value.Errors;
                        foreach (var error in errors)
                        {
                            cMensaje += " " + error.ErrorMessage + "\n";
                        }
                    }

                    return Json(new { success = false, message = cMensaje });
                }

                if (medicamento.nIdMedicamento == 0)
                    await _service.AddAsync(medicamento);
                else
                    await _service.UpdateAsync(medicamento);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}

