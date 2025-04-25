using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime FechaPedido { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        [MaxLength(20)]
        public string Estado { get; set; } 
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        public ICollection<DetallePedido> DetallesPedido { get; set; }
        = new List<DetallePedido>();

    }
}
