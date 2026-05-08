using CS2WeeklyManage.Models;
using CS2WeeklyManage.Models.Commons;
using Microsoft.EntityFrameworkCore;

namespace CS2WeeklyManage.Repositories.Implementations
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Item> items;

        public ItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            items = dbContext.Set<Item>();
        }

        public async Task<Item?> AddAsync(Item request)
        {
            try
            {
                var result = await items.AddAsync(request);
                return result.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(Item request)
        {
            try
            {
                items.Remove(request);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Item?> FindByIdAsync(long id)
        {
            try
            {
                return await items.FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception ex)
            {
                return null!;
            } 
        }

        public async Task<List<Item>> GetAllAsync()
        {
            try
            {
                return await items.ToListAsync();
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        public bool Update(Item request)
        {
            try
            {
                items.Update(request);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}