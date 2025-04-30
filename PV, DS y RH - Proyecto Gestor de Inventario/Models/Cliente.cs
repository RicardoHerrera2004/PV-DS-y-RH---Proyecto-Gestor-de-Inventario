using System.ComponentModel.DataAnnotations;

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio."), StringLength(50)]    
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio."), StringLength(50)]
        public string Apellido { get; set; }
        [Phone(ErrorMessage = "El campo Teléfono no es un número de teléfono válido.")]
        public string Telefono { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } 
        public Cliente()
        {
            Pedidos = new List<Pedido>();
        }
    }
}
