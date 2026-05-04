namespace CS2WeeklyManage.Repositories
{
    public interface IUnitOfWork
    {
        IItemRepository ItemRepository { get; }
        Task SaveChangeAsync();
    }
}