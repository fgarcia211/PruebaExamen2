using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaExamen.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }

        [Column("FECHA_PEDIDO")]
        public DateTime FechaPedido { get; set; }
    }
}
