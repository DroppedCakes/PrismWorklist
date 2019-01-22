using Dapper.FastCrud;
using PrismWorkList.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWorkList.Infrastructure
{
    class OrderPatientViewDao
    {
        private readonly IDbConnection _dbConnection;

        public OrderPatientViewDao(IDbConnection dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public IEnumerable<OrderPatientView> FindByOrderNumber(string orderNumber)
            => _dbConnection.Find<OrderPatientView>();

        public virtual void Update(OrderPatientView examinationOrder)
            => _dbConnection.Update(examinationOrder);

        public virtual void Insert(OrderPatientView examinationOrder)
            => _dbConnection.Insert(examinationOrder);

    }
}
