namespace VentaAccesorioss.Models;

public partial class Producto
{
    public int IdProducto { get; set; }
    public string Nombre { get; set; } = null!;
    public string Categoria { get; set; } = null!;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public int IdMarca { get; set; }
    public virtual Marca? IdMarcaNavigation { get; set; }
}
