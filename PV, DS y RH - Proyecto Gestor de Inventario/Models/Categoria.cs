using System.ComponentModel.DataAnnotations;

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio."), StringLength(50)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
