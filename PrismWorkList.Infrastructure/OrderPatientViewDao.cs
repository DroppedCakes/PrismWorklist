using Dapper.FastCrud;
using PrismWorkList.Infrastructure.Models;
using System.Collections.Generic;
using System.Data;

namespace PrismWorkList.Infrastructure
{
    public class OrderPatientViewDao
    {
        /// <summary>
        /// 
        /// </summary>
        public OrderPatientViewDao()
        {
        }

        public IEnumerable<OrderPatientView> FetchOrders(IDbConnection db)
            => db.Find<OrderPatientView>();

        public IEnumerable<OrderPatientView> FetchOrders(IDbConnection db,string currentDate)
            => db.Find<OrderPatientView>(statement => statement
            .Where($"{nameof(OrderPatientView.ExaminationDate):C} >= @CurrentDate")
            .OrderBy($"{nameof(OrderPatientView.ExaminationDate):C}ASC")
            .WithParameters(new
            {
                CurrentDate=currentDate
            })
            );
        
        public IEnumerable<OrderPatientView> FetchOrders(IDbConnection db,string since, string until)
            => db.Find<OrderPatientView>(statement => statement
            .Where($"{nameof(OrderPatientView.ExaminationDate):C} >= @DateSince AND @DateUntil>={nameof(OrderPatientView.ExaminationDate):C}")
            .OrderBy($"{nameof(OrderPatientView.ExaminationDate):C}ASC")
            .WithParameters(new
            {
                DateSince = since,
                DateUntil = until
            })
            );

        public virtual void Update(IDbConnection db,OrderPatientView examinationOrder)
            => db.Update(examinationOrder);

        public virtual void Insert(IDbConnection db,OrderPatientView examinationOrder)
            => db.Insert(examinationOrder);

    }
}
