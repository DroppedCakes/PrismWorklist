using System.Collections.Generic;
using PrismWorkList.Infrastructure.Models;
using PrismWorkList.Infrastructure;

namespace PrismWorkList.Service
{
    public class StudiesService : IStudiesService
    {
        private readonly OrderPatientViewDao _orderPatientViewDao;

        private readonly ITransactionContext _transactionContext;

        public StudiesService(ITransactionContext transactionContext,OrderPatientViewDao orderPatientViewDao)
        {
            _orderPatientViewDao = orderPatientViewDao;
            _transactionContext = transactionContext;
        }

        /// <summary>
        /// ワークリスト初期読込
        /// 当日の検査一覧を取得する
        /// </summary>
        /// <returns></returns>
        public IList<OrderPatientView> FetchOrderPatientsCurrentDay(string currentDate)
        {
            var retv = new List<OrderPatientView>();

            using (var transaction = _transactionContext.Open())
            {
                foreach (var order in this._orderPatientViewDao.FetchOrders(_transactionContext.Connection,currentDate))
                {
                    retv.Add(order);
                }
            }
                           
            return retv;
        }

        /// <summary>
        /// ワークリスト全件取得
        /// </summary>
        /// <returns></returns>
        public IList<OrderPatientView> FetchOrderPatients()
        {
            var retv = new List<OrderPatientView>();
            using (var transaction = _transactionContext.Open())
            {
                foreach (var order in this._orderPatientViewDao.FetchOrders(_transactionContext.Connection))
                {
                    retv.Add(order);
                }
            }
            return retv;
        }

        /// <summary>
        /// ワークリスト再読み込み
        /// </summary>
        /// <returns></returns>
        public IList<OrderPatientView> FetchOrderPatients(string since, string until)
        {
            var retv = new List<OrderPatientView>();
            using (var transaction = _transactionContext.Open())
            {
                foreach (var order in this._orderPatientViewDao.FetchOrders(_transactionContext.Connection, since, until))
                {
                    retv.Add(order);
                }
            }

            return retv;
        }
    }
}
