using StudentEnrollment.data.Models;

namespace StudentEnrollment.data.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEnitiy
    {
        Task<TEntity> GetAsync(int? id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task UpdateAsync(TEntity entity);

        Task<bool> ExitsAync(int id);   
    }
}
