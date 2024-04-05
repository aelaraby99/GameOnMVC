using Games.DAL.Data.Models;


namespace Games.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int Id);
        Task AddAsync(T Entity);
        void Delete(T Entity);
        void Update(T Entity);
    }
}
