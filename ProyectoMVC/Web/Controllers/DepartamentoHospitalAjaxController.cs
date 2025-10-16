using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Web.Controllers
{
    // Cambiamos el nombre del controlador
    public class DepartamentoHospitalAjaxController : Controller
    {
        // Usamos la interfaz del servicio de DepartamentoHospital
        private readonly IDepartamentoHospitalService _service;

        public DepartamentoHospitalAjaxController(IDepartamentoHospitalService service)
        {
            _service = service;
        }

        // --- Vista principal (Muestra la tabla) ---
        public async Task<IActionResult> Index()
        {
            var departamentos = await _service.GetAllAsync();
            return View(departamentos);
        }

        // --- Acción AJAX para obtener el formulario parcial (Create/Edit) ---
        [HttpGet]
        public IActionResult Form(int? id)
        {
            if (id == null || id == 0)
                // Usamos el nuevo nombre del PartialView
                return PartialView("_FormularioDepartamentoHospital", new DepartamentoHospital());
            else
            {
                // Usamos el servicio para obtener el objeto, manejando el Task<T>
                var departamento = _service.GetByIdAsync(id.Value).Result;
                return PartialView("_FormularioDepartamentoHospital", departamento);
            }
        }

        // --- Acción AJAX POST para Guardar (Insertar o Actualizar) ---
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] DepartamentoHospital departamento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Recolección manual de errores para devolver vía JSON
                    var cMensaje = "";
                    foreach (var item in ModelState)
                    {
                        foreach (var error in item.Value.Errors)
                        {
                            cMensaje = cMensaje + " " + error.ErrorMessage + "\n";
                        }
                    }

                    return Json(new { success = false, message = cMensaje });
                }

                // Usamos el ID de nuestro modelo: nIdDepartamento
                if (departamento.nIdDepartamento == 0)
                    await _service.AddAsync(departamento);
                else
                    await _service.UpdateAsync(departamento);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // --- Acción AJAX POST para Eliminar ---
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