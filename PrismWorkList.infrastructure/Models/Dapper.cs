using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using Dapper.FastCrud;

namespace PrismWorkList.Infrastructure.Models
{
   public class Dapper
    {
        public IEnumerable<OrderPatientView> FetchWorkList()
        {
            var settings = ConfigurationManager.ConnectionStrings["PGTraining"];
            var factory = System.Data.Common.DbProviderFactories.GetFactory(settings.ProviderName);
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = settings.ConnectionString;
                connection.Open();

                var retv = connection.Find<OrderPatientView>(statement => statement
                                  .Where($"{nameof(OrderPatientView.ExaminationDate)}=@examDate")
                                  .WithParameters(new { examDate = "2018-10-28" }));

                return retv;
            }
        }
    }
}
