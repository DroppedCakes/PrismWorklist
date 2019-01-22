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
    public class OrderPatientViewDao
    {
        private readonly IDbConnection _dbConnection;

        public OrderPatientViewDao(IDbConnection dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public IEnumerable<OrderPatientView> FetchOrders()
            => _dbConnection.Find<OrderPatientView>();

        public IEnumerable<OrderPatientView> FetchOrders(DateTime since,DateTime until)
        {
            var retv=_dbConnection.Find<OrderPatientView>(statement => statement
            .Where($"@since=<{nameof(OrderPatientView.ExaminationDate)} AND{nameof(OrderPatientView.ExaminationDate)}=<@until")
            .WithParameters(new { since, until })
            );
            return retv;
        }


        public virtual void Update(OrderPatientView examinationOrder)
            => _dbConnection.Update(examinationOrder);

        public virtual void Insert(OrderPatientView examinationOrder)
            => _dbConnection.Insert(examinationOrder);

    }
}
