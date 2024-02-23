using Goods.Core.Models;

namespace Goods.Core.Abstractions
{
    public interface IUserRepository
    {
        Task<Guid> Create(Users user);
        Task<Guid> Delete(Guid id);
        Task<List<Users>> GetAll();
        Task<Users?> GetByEmail(string mail);
        Task<Guid> Update(Guid id, string name, string surname, string password, string mail);
    }
}