using Games.BLL.Interfaces;
using Games.DAL.Data.Contexts;
using Games.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace GameOn.BLL.Repositories
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public void DetachEntity(Game entity)
        {
           _dbContext.Entry(entity).State = EntityState.Detached;
        }
    }
}
