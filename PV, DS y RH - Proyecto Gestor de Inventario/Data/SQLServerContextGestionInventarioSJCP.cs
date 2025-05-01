using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models;

public class SQLServerContextGestionInventarioSJCP : DbContext
{
    public SQLServerContextGestionInventarioSJCP(DbContextOptions<SQLServerContextGestionInventarioSJCP> options)
        : base(options)
    {
    }

    public DbSet<PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models.Categoria> Categoria { get; set; } = default!;

    public DbSet<PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models.Cliente> Cliente { get; set; } = default!;

    public DbSet<PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models.DetallePedido> DetallePedido { get; set; } = default!;

    public DbSet<PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models.Pedido> Pedido { get; set; } = default!;

    public DbSet<PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models.Producto> Producto { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Ropa", Descripcion = "Prendas de vestir: camisetas, pantalones, chaquetas…" },
            new Categoria { Id = 2, Nombre = "Comida", Descripcion = "Alimentos en conserva, envasados y frescos." },
            new Categoria { Id = 3, Nombre = "Bebidas", Descripcion = "Bebidas alcohólicas y no alcohólicas." },
            new Categoria { Id = 4, Nombre = "Abarrotes", Descripcion = "Productos de despensa: cereales, lácteos, granos." },
            new Categoria { Id = 5, Nombre = "Joyas", Descripcion = "Collares, anillos, pulseras y accesorios metálicos." },
            new Categoria { Id = 6, Nombre = "Fármacos", Descripcion = "Medicamentos y productos de cuidado de la salud." },
            new Categoria { Id = 7, Nombre = "Otros", Descripcion = "Artículos diversos que no encajan en las categorías anteriores." }
        );
    }
}
