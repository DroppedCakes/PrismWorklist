using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FastCrud;
using PrismWorkList.Infrastructure.Models;

namespace PrismWorkList.Infrastructure
{
    public class PatientDao
    {
        public PatientDao()
        {
        }

        public virtual IEnumerable<Gender> GetGender(IDbConnection db) => db.Find<Gender>();

        public virtual PatientInfo FindByPatientID(IDbConnection db,string patientID)
        {
            return db.Find<PatientInfo>(statement =>
            statement.Where($"{nameof(PatientInfo.PatientID)}='{patientID}'")
            ).SingleOrDefault();
        }

        public virtual void Update(IDbConnection db,PatientInfo patient)
            => db.Update(patient);

        public virtual void Insert(IDbConnection db,PatientInfo patient)
            => db.Insert(patient);
    }
}
