using Microsoft.EntityFrameworkCore;
using web2REST.Model;
using web2REST.Model.Context;
using web2REST.Repository.Generic;

namespace web2REST.Repository.Implementations
{
    public class ComandasRepositoryImplementation : GenericRepository<Comanda>, IComandasRepository
    {
        private readonly IRepository<Comanda> _repository;

        private readonly MySQLContext _context;

        public ComandasRepositoryImplementation(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public List<Comanda> FindAll()
        {
            return _repository.FindAll();
        }

        public Comanda FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Comanda Create(Comanda comanda)
        {
            return _repository.Create(comanda);
        }

        public Comanda Update(Comanda comanda)
        {
            return _repository.Update(comanda);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Comanda FindWithProdutos(long id)
        {
            return _context.Comandas
                .Include(c => c.Produtos)
                .FirstOrDefault(c => c.Id == id);
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
