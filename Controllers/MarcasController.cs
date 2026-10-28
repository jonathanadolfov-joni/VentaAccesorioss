using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentaAccesorioss.Models;

namespace VentaAccesorioss.Controllers;

public class MarcasController : Controller
{
    private readonly VentaAccesoriosContext _context;
    public MarcasController(VentaAccesoriosContext context) { _context = context; }

    public async Task<IActionResult> Index() => View(await _context.Marcas.ToListAsync());
}
