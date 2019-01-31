using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FastCrud;
using PrismWorkList.Infrastructure.Models;

namespace PrismWorkList.Infrastructure
{
    public class PatientDao
    {
        private readonly ITransactionContext _transactionContext;

        public PatientDao(ITransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public virtual PatientInfo FindByPatientID(string patientID)
        {
            return _transactionContext.Connection.Find<PatientInfo>(statement =>
            statement.Where($"{nameof(PatientInfo.PatientID)}='{patientID}'")
            ).SingleOrDefault();
        }

        public virtual void Update(PatientInfo patient)
            => _transactionContext.Connection.Update(patient);

        public virtual void Insert(PatientInfo patient)
            => _transactionContext.Connection.Insert(patient);
    }
}
