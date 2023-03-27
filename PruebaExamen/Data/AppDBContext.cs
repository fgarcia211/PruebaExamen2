using Microsoft.EntityFrameworkCore;
using PruebaExamen.Models;

namespace PruebaExamen.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ArticuloPedido> ArticuloPedidos { get; set; }
    }
}
