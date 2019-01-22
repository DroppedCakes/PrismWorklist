using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismWorkList.Infrastructure.Models;

namespace PrismWorkList.Domain
{
   public interface IStudiesService
    {
        IList<OrderPatientView> FetchOrderPatients();
    }
}
