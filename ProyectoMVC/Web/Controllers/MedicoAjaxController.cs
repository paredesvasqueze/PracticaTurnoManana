using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Controllers
{
    public class MedicoAjaxController : Controller
    {
        private readonly IMedicoService _service;

        public MedicoAjaxController(IMedicoService service)
        {
            _service = service;
        }

        // GET: api/MedicoAjax
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicos = await _service.GetAllAsync();
            return Ok(medicos);
        }

    }
}
