using Goods.Core.Models;
using Goods.DataBase.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods.Services.Services
{
    public class GoodsService
    {
        private readonly IGoodRepository _goodRepository;
        public GoodsService(IGoodRepository repository) => _goodRepository = repository;


        public async Task<List<Good>> GetAllGoods()
        {
            return await _goodRepository.GetAll();
        }

        public async Task<Good?> GetGoodsById(Guid id)
        {
            return await _goodRepository.GetById(id);
        }

        public async Task Create(Good good)
        {
            await _goodRepository.Create(good);
        }

        public async Task Update(Guid id, string title, decimal price, string description)
        {
            await _goodRepository.Update(id, title, price, description);
        }

        public async Task Delete(Guid id)
        {
            await _goodRepository.Delete(id);
        }
    }
}
