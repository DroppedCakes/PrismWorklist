using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismWorkList.Infrastructure.Models;

namespace PrismWorkList.Service
{
   public interface IStudiesService
    {
        IList<OrderPatientView> FetchOrderPatientsCurrentDay(string currentDate);
        IList<OrderPatientView> FetchOrderPatients(string since,string until);  
    }
}
