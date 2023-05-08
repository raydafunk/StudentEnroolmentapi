using StudentEnrollment.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.data.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEnitiy
    {
        Task<TEntity> GetAsync(int? id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(TEntity entity);

        Task<bool> ExitsAync(int id);   
    }
}
