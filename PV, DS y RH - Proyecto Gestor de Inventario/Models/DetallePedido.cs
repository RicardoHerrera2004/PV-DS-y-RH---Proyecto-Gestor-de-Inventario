using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models
{
    public class DetallePedido
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio."), Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero."), Column(TypeName = "decimal(18,2)")]
        public decimal PrecioOriginal { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio."), Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero."), Column(TypeName = "decimal(18,2)")]
        public decimal PrecioVendido { get; set; }
        public string Obervacion { get; set; }
        public int PedidoId { get; set; }
        [ForeignKey("PedidoId")]
        public Pedido? Pedido { get; set; }
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

    }
}
