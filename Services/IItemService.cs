using CS2WeeklyManage.Models;

namespace CS2WeeklyManage.Services
{
    public interface IItemService {
        public Task<Item> GetById(long id);
        public Task<List<Item>> GetAll(long id);
        public Task<Item> Add(Item request);
        public Task<bool> Update(Item request);
        public Task<bool> Delete(Item request);
    }
}
