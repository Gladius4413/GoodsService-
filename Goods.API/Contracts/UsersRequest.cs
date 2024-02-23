namespace Goods.API.Contracts
{
    public record UsersRequest(
        string Name,
        string Surname,
        string Mail,
        string password
        );

}
