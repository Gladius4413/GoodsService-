using Goods.Core.Models;

namespace Goods.Core.Abstractions
{
    public interface IGoodsService
    {
        Task Create(Good good);
        Task Delete(Guid id);
        Task<List<Good>> GetAllGoods();
        Task<Good?> GetGoodsById(Guid id);
        Task Update(Guid id, string title, decimal price, string description);
    }
}