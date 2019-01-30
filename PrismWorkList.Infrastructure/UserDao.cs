using System.Data;
using System.Linq;
using Dapper.FastCrud;
using PrismWorkList.Infrastructure.Models;

namespace PrismWorkList.Infrastructure
{
    public class UserDao
    {
        private readonly IDbConnection _dbConnection;

        public UserDao(IDbConnection dbConnection)
        {
            this._dbConnection= dbConnection;
        }

        public virtual User FindByLoginId(string loginID)
        {
            return _dbConnection.Find<User>(statement =>
            statement
            .Where($"{nameof(User.UserID)}='{loginID}'")
            ).SingleOrDefault();
        }

        public virtual void Update(User user)
            => _dbConnection.Update(user);

        public virtual void Insert(User user)
            => _dbConnection.Insert(user);

    }
}
