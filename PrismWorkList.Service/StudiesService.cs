using PrismWorkList.Infrastructure;
using PrismWorkList.Infrastructure.Models;
using System.Collections.Generic;

namespace PrismWorkList.Service
{
    public class StudiesService : IStudiesService
    {
        private readonly ITransactionContext _transactionContext;

        private readonly OrderPatientViewDao _orderPatientViewDao;

        private readonly PatientDao _patientDao;
        
        public StudiesService(ITransactionContext transactionContext,OrderPatientViewDao orderPatientViewDao,PatientDao patientDao)
        {
            _transactionContext = transactionContext;
            _orderPatientViewDao = orderPatientViewDao;
            _patientDao = patientDao;
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

        public IList<Gender> GetGenders()
        {
            var retv = new List<Gender>();
            using (var transaction = _transactionContext.Open())
            {
                foreach(var gender  in this._patientDao.GetGender(_transactionContext.Connection))
                {
                    retv.Add(gender);
                }
                return retv;
            }
        }
    }
}
