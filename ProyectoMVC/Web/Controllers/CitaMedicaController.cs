using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace TuProyecto.Controllers
{
    public class CitaMedicaController : Controller
    {
        private readonly ICitaMedicaServiceDb _citaMedicaServiceDb;

        public CitaMedicaController(ICitaMedicaServiceDb citaMedicaServiceDb)
        {
            _citaMedicaServiceDb = citaMedicaServiceDb;
        }

        public IActionResult Index()
        {
            var citas = _citaMedicaServiceDb.GetAll();
            return View(citas);
        }


        [HttpGet("CitaMedica/Create")]
        [HttpGet("CitaMedica/Crear")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("CitaMedica/Create")]
        [HttpPost("CitaMedica/Crear")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CitaMedica cita)
        {
            if (ModelState.IsValid)
            {
                _citaMedicaServiceDb.Insert(cita);
                return RedirectToAction(nameof(Index));
            }
            return View(cita);
        }

        public IActionResult Edit(int id)
        {
            var cita = _citaMedicaServiceDb.GetById(id);
            if (cita == null)
            {
                return NotFound();
            }
            return View(cita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CitaMedica cita)
        {
            if (ModelState.IsValid)
            {
                _citaMedicaServiceDb.Update(cita);
                return RedirectToAction(nameof(Index));
            }
            return View(cita);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _citaMedicaServiceDb.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
