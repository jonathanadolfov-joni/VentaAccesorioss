using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentaAccesorioss.Models;

namespace VentaAccesorioss.Controllers;

public class UsuariosController : Controller
{
    private readonly VentaAccesoriosContext _context;
    public UsuariosController(VentaAccesoriosContext context) { _context = context; }

    public async Task<IActionResult> Index() => View(await _context.Usuarios.ToListAsync());
}
