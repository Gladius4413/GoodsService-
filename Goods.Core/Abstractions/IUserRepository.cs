using Goods.Core.Models;

namespace Goods.DataBase.Repositories
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task Delete(Guid id);
        Task<List<User>> GetAll();
        Task<User?> GetByEmail(string mail);
        Task Update(Guid id, string name, string surname, string password, string mail);
    }
}