using CS2WeeklyManage.Models;

namespace CS2WeeklyManage.Services.Implementations
{
    public class ItemService : IItemService {
        private readonly IUnitOfWork _unitOfWork;
        
        public ItemService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public Task<Item> GetById(long id) {
            try {
                var result = await _unitOfWork.ItemRepository.FindByIdAsync(id);
                return result;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public Task<List<Item>> GetAll() {
            try {
                var items = await _unitOfWork.ItemRepository.GetAllAsync();
            }
            catch (Exception ex) {
                return [];
            }
        }

        public Task<Item> Add(Item request) {
            try {
                var result = await _unitOfWork.ItemRepository.AddAsync(request);
                await _unitOfWork.SaveChangeAsync();

                return result;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public Task<bool> Update(Item request) {
            try {
                var item = await _unitOfWork.ItemRepository.FindByIdAsync(request.Id);
                if (item is null) {
                    // throw not found exception here
                    throw new Exception("Not found item");
                }

                // do mapper here
                _unitOfWork.ItemRepository.Update(item);
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex) {
                return false;
            }
        }

        public Task<bool> Delete(Item request) {
            try {
                var item = await _unitOfWork.ItemRepository.FindByIdAsync(request.Id);
                if (item is null) {
                    // throw not found exception here
                    throw new Exception("Not found item");
                }

                _unitOfWork.ItemRepository.Delete(item);
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex) {
                return false;
            }
        }
    }   
}