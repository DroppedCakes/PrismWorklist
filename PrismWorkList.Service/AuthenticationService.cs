using PrismWorkList.Infrastructure;

namespace PrismWorkList.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserDao _userDao;

        public AuthenticationService(UserDao userDao)
        {
            _userDao = userDao;
        }

        public bool TryLoginAuthorization(string id, string password)
        {
            return true;
        }
    }
}
