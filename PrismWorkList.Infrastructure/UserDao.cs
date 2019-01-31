using System.Data;
using System.Linq;
using Dapper.FastCrud;
using PrismWorkList.Infrastructure.Models;

namespace PrismWorkList.Infrastructure
{
    public class UserDao
    {
        private readonly ITransactionContext _transactionContext;

        public UserDao(ITransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public virtual User FindByLoginId(string loginID)
        {
            return _transactionContext.Connection.Find<User>(statement =>
            statement
            .Where($"{nameof(User.UserID)}='{loginID}'")
            ).SingleOrDefault();
        }

        public virtual void Update(User user)
            => _transactionContext.Connection.Update(user);

        public virtual void Insert(User user)
            => _transactionContext.Connection.Insert(user);

    }
}
