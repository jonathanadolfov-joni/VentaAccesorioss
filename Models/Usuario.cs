namespace VentaAccesorioss.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string Rol { get; set; } = null!;
}
