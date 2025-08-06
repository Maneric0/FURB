using web2REST.Model;

namespace web2REST.Repository
{
    public interface IComandasRepository : IRepository<Comanda>
    {
        Comanda FindWithProdutos(long id);
    }
}
