using System.ComponentModel.DataAnnotations;

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models
{
    public class ProductoImage
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        [Required, MaxLength(200)]
        public string Url { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaSubida { get; set; }
    }
}
