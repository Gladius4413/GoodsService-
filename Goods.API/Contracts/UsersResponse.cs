namespace Goods.API.Contracts
{
    public record UsersResponse(
        Guid id,
        string Name,
        string Surname,
        string Mail,
        string password
        );

}
