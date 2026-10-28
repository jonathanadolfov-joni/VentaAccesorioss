using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentaAccesorioss.Models;

namespace VentaAccesorioss.Controllers;

public class HomeController : Controller
{
    private readonly VentaAccesoriosContext _context;
    public HomeController(VentaAccesoriosContext context) { _context = context; }

    public async Task<IActionResult> Index()
    {
        var destacados = await _context.Productos
            .Include(p => p.IdMarcaNavigation)
            .OrderByDescending(p => p.Precio)
            .Take(4)
            .ToListAsync();
        return View(destacados);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
