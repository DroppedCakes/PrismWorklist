using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWorkList.Infrastructure.Models
{
    public class StudyOrder
    {
        public int ID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime ExaminationDate { get; set; }
        public string ProcessingDivision { get; set; }
        public int InfoID { get; set; }
        public string ExaminationTypeCode { get; set; }
        public string ExaminationTypeName { get; set; }
        public string Comment { get; set; }
        public string PatientID { get; set; }
        public string KanjiName { get; set; }
        public string KanaName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
