namespace PrismWorkList.Service
{
    public interface IAuthenticationService
    {
        bool TryLoginAuthorization(string id, string password);
    }
}
