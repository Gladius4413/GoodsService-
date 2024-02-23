using Goods.Core.Models;

namespace Goods.Core.Abstractions
{
    public interface IUsersService
    {
        Task<Guid> Create(Users user);
        Task<Guid> Delete(Guid id);
        Task<List<Users>> GetAllUsers();
        Task<Users?> GetUserByMail(string mail);
        Task<Guid> Update(Guid id, string name, string surname, string mail, string password);
    }
}