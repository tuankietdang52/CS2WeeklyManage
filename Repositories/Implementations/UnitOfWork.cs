using CS2WeeklyManage.Models.Commons;

namespace CS2WeeklyManage.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _dbContext;
        public IItemRepository ItemRepository { get; }

        public UnitOfWork(
            AppDbContext dbContext,
            IItemRepository itemRepository)
        {
            _dbContext = dbContext;
            ItemRepository = itemRepository;
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}