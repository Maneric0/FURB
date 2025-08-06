using web2REST.Model;

namespace web2REST.Business
{
    public interface IComandasBusiness
    {
        Comanda Create(Comanda comanda);

        Comanda FindById(int id);

        List<Comanda> FindAll();

        Comanda Update(Comanda comanda);

        void Delete(int id);
    }
}
