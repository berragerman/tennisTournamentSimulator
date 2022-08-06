using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournamentSimulator.Domain.Entities;

namespace TennisTournamentSimulator.ApplicationCore.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task<T> Get(int id);
        public Task<T[]> GetAll();
        public Task Create(T entity);
        public Task Update(int id, T entity);
        public Task Delete(int id);
    }
}
