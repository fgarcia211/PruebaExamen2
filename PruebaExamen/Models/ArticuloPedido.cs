using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaExamen.Models
{
    [Table("Articulos_Pedido")]
    public class ArticuloPedido
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("IDPEDIDO")]
        public int IdPedido { get; set; }

        [Column("IDARTICULO")]
        public int IdArticulo { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        [Column("CANTIDAD")]
        public int Cantidad { get; set; }
    }
}
