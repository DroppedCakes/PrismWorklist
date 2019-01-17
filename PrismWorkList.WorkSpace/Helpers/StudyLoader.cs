using PrismWorkList.Infrastructure.Models;
using PrismWorkList.WorkSpace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWorkList.WorkSpace.Helpers
{
   public class StudyLoader
    {
        public void FetchWorkList()
        {
            //        var connectionString = "Data Source=FUJIOKA-PC\SQLEXPRESS;Initial Catalog=PGTraining;Integrated Security=True;";
            //        var factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            //        using (var connection = factory.CreateConnection())
            //        {
            //            connection.ConnectionString = settings.ConnectionString;
            //            connection.Open();

            //            var studies = connection.Find<StudyOrder>(statement => statement
            //                               .Where($"{nameof(OrderPatientView.ExaminationDate)}=@examDate")
            //                               .WithParameters(new { StudyDateSince = "2018-10-18" })
            //                               .WithParameters(new { StudyDateUntil = "2018-10-18" }));

            //            foreach (StudyOrder study in studies)
            //        {
            //            yield return StudyViewModel.Create(study);
            //        }
        }
    }
}
