using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS2WeeklyManage.Repositories
{
    public interface IRepository<TModel>
    {
        public Task<List<TModel>> GetAllAsync();
        public Task<TModel?> FindByIdAsync(long id);
        public Task<TModel?> AddAsync(TModel request);
        public bool Update(TModel request);
        public bool Delete(TModel request);
    }
}