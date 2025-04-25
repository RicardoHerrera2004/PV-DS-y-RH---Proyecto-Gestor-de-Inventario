using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models;

    public class SQLServerContextGestionInventarioSJCP : DbContext
    {
        public SQLServerContextGestionInventarioSJCP (DbContextOptions<SQLServerContextGestionInventarioSJCP> options)
            : base(options)
        {
        }

        public DbSet<PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models.Categoria> Categoria { get; set; } = default!;

public DbSet<PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models.Cliente> Cliente { get; set; } = default!;

public DbSet<PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models.DetallePedido> DetallePedido { get; set; } = default!;

public DbSet<PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models.Pedido> Pedido { get; set; } = default!;

public DbSet<PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models.Producto> Producto { get; set; } = default!;
    }
