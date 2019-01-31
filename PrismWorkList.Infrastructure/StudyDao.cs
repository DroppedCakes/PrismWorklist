using Dapper.FastCrud;
using PrismWorkList.Infrastructure.Models;
using System.Linq;

namespace PrismWorkList.Infrastructure
{
    public class StudyDao
    {
        private readonly ITransactionContext _transactionContext;

        public StudyDao(ITransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public virtual ExaminationOrder FindByOrderNumber(string orderNumber)
        {
            return _transactionContext.Connection.Find<ExaminationOrder>(statement =>
            statement
            .Where($"{nameof(ExaminationOrder.OrderNumber)}=''{orderNumber}")
            ).SingleOrDefault();
        }

        public virtual void Update(ExaminationOrder examinationOrder)
            =>_transactionContext.Connection.Update(examinationOrder);

        public virtual void Insert(ExaminationOrder examinationOrder)
            => _transactionContext.Connection.Insert(examinationOrder);

    }
}
