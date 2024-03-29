﻿using Goods.Core.Models;

namespace Goods.Core.Abstractions
{
    public interface IGoodRepository
    {
        Task Create(Good good);
        Task Delete(Guid id);
        Task<List<Good>> GetAll();
        Task<Good?> GetById(Guid id);
        Task Update(Guid id, string title, decimal price, string description);
    }
}