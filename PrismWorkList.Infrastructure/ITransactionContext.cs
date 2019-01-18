using System.Data;

namespace PrismWorkList.Infrastructure
{
    public interface ITransactionContext
    {
       IDbConnection Connection { get; }

        ITransaction Open();
    }
}
