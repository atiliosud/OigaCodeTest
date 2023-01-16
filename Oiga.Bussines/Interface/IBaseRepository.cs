using Oiga.Bussines.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiga.Bussines.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task Delete(Guid id);
        Task Update(TEntity entity);
        Task<TEntity> Get(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
