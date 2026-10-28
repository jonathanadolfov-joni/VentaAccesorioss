using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VentaAccesorioss.Models;

namespace VentaAccesorioss.Controllers;

public class ProductosController : Controller
{
    private readonly VentaAccesoriosContext _context;
    public ProductosController(VentaAccesoriosContext context) { _context = context; }

    public async Task<IActionResult> Index()
    {
        var productos = await _context.Productos
            .Include(p => p.IdMarcaNavigation)
            .OrderBy(p => p.Nombre)
            .ToListAsync();
        return View(productos);
    }

    public IActionResult Create()
    {
        ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "Nombre");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Producto producto)
    {
        ModelState.Remove(nameof(Producto.IdMarcaNavigation));
        if (ModelState.IsValid)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "Nombre", producto.IdMarca);
        return View(producto);
    }
}
