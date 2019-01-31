using Dapper.FastCrud;
using PrismWorkList.Infrastructure.Models;
using System.Data;
using System.Linq;

namespace PrismWorkList.Infrastructure
{
    public class UserDao
    {
         public UserDao()
        {
        }

        public virtual User FindByLoginId(IDbConnection db,string loginID)
        {
            return db.Find<User>(statement =>
            statement
            .Where($"{nameof(User.UserID)}='{loginID}'")
            ).SingleOrDefault();
        }

        public virtual void Update(IDbConnection db,User user)
            => db.Update(user);

        public virtual void Insert(IDbConnection db,User user)
            => db.Insert(user);

    }
}
