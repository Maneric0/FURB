using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using web2REST.Model;
using web2REST.Model.Context;
using web2REST.Repository;
using System;

namespace web2REST.Business.Implementations
{
    public class ComandasBusinessImplementation : IComandasBusiness
    {
        private readonly IRepository<Comanda> _repository;

        public ComandasBusinessImplementation(IRepository<Comanda> repository)
        {
            _repository = repository;
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
    }
}
