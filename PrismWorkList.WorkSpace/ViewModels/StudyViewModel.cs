using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismWorkList.Domain;
using PrismWorkList.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismWorkList.WorkSpace.ViewModels
{
    public class StudyViewModel : BindableBase
    {
        
        public bool IsSelected { get; set; }
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

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="study"></param>
        public StudyViewModel()
        {

        }
    }
}
