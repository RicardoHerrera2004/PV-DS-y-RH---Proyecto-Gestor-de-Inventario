using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio."), StringLength(100)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio."), Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser un número entero no negativo.")]
        public int Cantidad { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
