using PrismWorkList.Infrastructure.Models;
using PrismWorkList.WorkSpace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FastCrud;

namespace PrismWorkList.WorkSpace.Helpers
{
    public class StudyLoader
    {
        /// <summary>
        /// 接続文字列
        /// </summary>
        public string DBConnectionString { get; set; }

        public StudyLoader()
        {
            this.DBConnectionString = "Data Source=FUJIOKA-PC\\SQLEXPRESS;Initial Catalog=PGTraining;Integrated Security=True;";
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<StudyViewModel> FetchWorkList(DateTime? since,DateTime? until)
        {
            var factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = this.DBConnectionString;
                connection.Open();

                var studies = connection.Find<StudyOrder>(statement => statement
                                   .Where($"{nameof(OrderPatientView.ExaminationDate)}='{since}'"));
;
                foreach (StudyOrder study in studies)
                {
                    yield return StudyViewModel.Create(study);
                }
            }
        }
    }
}
