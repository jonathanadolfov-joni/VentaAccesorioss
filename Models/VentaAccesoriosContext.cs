using Microsoft.EntityFrameworkCore;

namespace VentaAccesorioss.Models;

public partial class VentaAccesoriosContext : DbContext
{
    public VentaAccesoriosContext(DbContextOptions<VentaAccesoriosContext> options) : base(options) { }

    public virtual DbSet<Marca> Marcas { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marca>(e => { e.HasKey(x => x.IdMarca); });
        modelBuilder.Entity<Producto>(e =>
        {
            e.HasKey(x => x.IdProducto);
            e.Property(x => x.Precio).HasColumnType("decimal(10, 2)");
            e.HasOne(p => p.IdMarcaNavigation).WithMany(m => m.Productos).HasForeignKey(p => p.IdMarca);
        });
        modelBuilder.Entity<Usuario>(e => { e.HasKey(x => x.IdUsuario); });
    }
}
