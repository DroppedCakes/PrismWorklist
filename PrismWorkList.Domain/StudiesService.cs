using System.Collections.Generic;
using PrismWorkList.Infrastructure.Models;
using PrismWorkList.Infrastructure;
using System;

namespace PrismWorkList.Domain
{
    public class StudiesService : IStudiesService
    {
        private readonly OrderPatientViewDao _orderPatientViewDao;

        public StudiesService(OrderPatientViewDao orderPatientViewDao)
        {
            this._orderPatientViewDao = orderPatientViewDao;
        }

        public IList<OrderPatientView> FetchOrderPatients()
        {
            var retv = new List<OrderPatientView>();
            foreach (var order in this._orderPatientViewDao.FetchOrders())
            {
                retv.Add(order);
            }
            return retv;
        }

        public IList<OrderPatientView> FetchOrderPatients(string since, string until)
        {
            var retv = new List<OrderPatientView>();
            foreach (var order in this._orderPatientViewDao.FetchOrders(since,until))
            {
                retv.Add(order);
            }
            return retv;
        }
    }
}
