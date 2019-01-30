using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismWorkList.Infrastructure.Models;
using Dapper.FastCrud;
using System.Data;

namespace PrismWorkList.Infrastructure
{
    public class StudyDao
    {
        private readonly IDbConnection _dbConnection;

        public StudyDao(IDbConnection dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public virtual ExaminationOrder FindByOrderNumber(string orderNumber)
        {
            return _dbConnection.Find<ExaminationOrder>(statement =>
            statement
            .Where($"{nameof(ExaminationOrder.OrderNumber)}=''{orderNumber}")
            ).SingleOrDefault();
        }

        public virtual void Update(ExaminationOrder examinationOrder)
            =>_dbConnection.Update(examinationOrder);

        public virtual void Insert(ExaminationOrder examinationOrder)
            => _dbConnection.Insert(examinationOrder);

    }
}
