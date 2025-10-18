using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Services;

namespace Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _service.GetAllAsync();
            return View(productos);
        }

        public async Task <IActionResult> Create()
        {
            var categorias = await _service.GetCategoriaAllAsync();

            ViewBag.Categorias = categorias
            .Select(c => new SelectListItem
            {
                Value = c.CategoriaId.ToString(),
                Text = c.Nombre
            })
            .ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            producto.cNombreCategoria = "aa";
            if (!ModelState.IsValid)
                return View(producto);

            await _service.AddAsync(producto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _service.GetByIdAsync(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            await _service.UpdateAsync(producto);
            return RedirectToAction(nameof(Index));
        }

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
