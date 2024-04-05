using Games.BLL.Interfaces;


namespace GameOn.BLL.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IDeviceRepository DeviceRepository { get; }
        IGameRepository GameRepository { get; }
        Task<int> CompleteAsync();
    }
}
