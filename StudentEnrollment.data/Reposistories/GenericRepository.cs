using Microsoft.EntityFrameworkCore;
using StudentEnrollment.data.Contracts;
using StudentEnrollment.data.Models;

namespace StudentEnrollment.data.Reposistories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEnitiy
    {
        private readonly StudentEnorllmentDbContext _db;

        public GenericRepository(StudentEnorllmentDbContext db)
        {
            this._db = db;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ExitsAync(int id)
        {
           var entity = await GetAsync(id);
            return await _db.Set<TEntity>().AnyAsync(q => q.Id == id);

        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int? id)
        {
            var result = await _db.Set<TEntity>().FindAsync(id);
            return result!;
        }

        public async Task UpdateAsync(TEntity entity)
        {
           _db.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
