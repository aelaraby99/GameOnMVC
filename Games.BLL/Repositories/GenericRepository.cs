using GameOn.BLL.Interfaces;
using Games.BLL.Interfaces;
using Games.DAL.Data.Contexts;
using Games.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOn.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T Entity)
        {
            await _dbContext.Set<T>().AddAsync(Entity);
        }
        public async Task<T> GetAsync(int Id)
        {
            if (typeof(T) == typeof(Game))
            {
                return  await _dbContext.Set<T>().Where(G=>G.Id==Id).Include(g => ((Game)(object)g).Category).Include(g => ((Game)(object)g).Devices).FirstOrDefaultAsync();
            }
            return await _dbContext.Set<T>().FindAsync(Id);
        }
        public void Update(T Entity)
        {
            _dbContext.Set<T>().Update(Entity);
        }
        public void Delete(T Entity)
        {
            _dbContext.Set<T>().Remove(Entity);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Game))
            {
                return (IEnumerable<T>)await _dbContext.Games.Include(G => G.Category).Include(G => G.Devices).ToListAsync();
            }
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
