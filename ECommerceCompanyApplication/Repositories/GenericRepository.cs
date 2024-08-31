using ECommerceCompanyApplication.Repositories.Contracts;
using ECommerceCompanyApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceCompanyApplication.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ECommerceDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(ECommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddData(T obj)
        {
            _dbSet.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteData(object ID)
        {
            var data = await _dbSet.FindAsync(ID);
            if (data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
            }
        }

        public async Task EditData(object ID, T obj)
        {
            var data = await _dbSet.FindAsync(ID);
            if (data != null)
            {
                _context.Entry(data).CurrentValues.SetValues(obj);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<T>> GetAllValues()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetValue(object ID)
        {
            return await _dbSet.FindAsync(ID);
        }
    }
}
