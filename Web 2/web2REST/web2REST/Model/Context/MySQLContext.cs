using Microsoft.EntityFrameworkCore;

namespace web2REST.Model.Context
{
    public class MySQLContext : DbContext
    {
       public MySQLContext() { }

       public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        
       public DbSet<Comanda> Comandas { get; set; }

       public DbSet <Produto> Produtos { get; set; }
    }
}