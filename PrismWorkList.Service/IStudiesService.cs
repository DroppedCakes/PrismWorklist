using PrismWorkList.Infrastructure.Models;
using System.Collections.Generic;

namespace PrismWorkList.Service
{
    public interface IStudiesService
    {
        IList<Gender> GetGenders();
        IList<OrderPatientView> FetchOrderPatientsCurrentDay(string currentDate);
        IList<OrderPatientView> FetchOrderPatients(string since,string until);  
    }
}
