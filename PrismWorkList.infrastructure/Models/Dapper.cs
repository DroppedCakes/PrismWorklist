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
        public IEnumerable<StudyOrder> FetchWorkList(DateTime? since,DateTime? until)
        {
            var settings = ConfigurationManager.ConnectionStrings["PGTraining"];
            var factory = System.Data.Common.DbProviderFactories.GetFactory(settings.ProviderName);
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = settings.ConnectionString;
                connection.Open();

                var workList= connection.Find<StudyOrder>(statement => statement
                                  .Where($"{nameof(OrderPatientView.ExaminationDate)}=@examDate")
                                  .WithParameters(new { StudyDateSince = "2018-10-18" })
                                  .WithParameters(new { StudyDateUntil = "2018-10-18" }));

                return workList;
            }
        }
    }
}
