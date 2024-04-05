using Games.BLL.Interfaces;
using Games.DAL.Data.Contexts;
using Games.DAL.Data.Models;
namespace GameOn.BLL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository 
    {
        public CategoryRepository(AppDbContext dbContext):base(dbContext)
        {
            
        }
    }
}
