using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournamentSimulator.ApplicationCore.Interfaces;
using TennisTournamentSimulator.Domain.Entities;

namespace TennisTournamentSimulator.ApplicationCore.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private IBaseRepository<T> repository;
        public BaseService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public Task Create(T entity)
        {
            return repository.Create(entity);
        }

        public Task Delete(int id)
        {
            return repository.Delete(id);
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T[]> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
