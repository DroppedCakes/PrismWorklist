namespace PrismWorkList.Service
{
    public interface IAuthenticationService
    {
        void TryLoginAuthorization(string id, string password);
    }
}
