using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismWorkList.Infrastructure.Models
{
    public class PatientInfo : BindableBase
    {
        // 患者属性情報のサロゲートキー
        private int _infoId;
        public int InfoId
        {
            get { return _infoId; }
            set { SetProperty(ref _infoId, value); }
        }

        // 患者ID
        private string _patientId;
        public string PatientID
        {
            get { return _patientId; }
            set { SetProperty(ref _patientId, value); }
        }

        // 漢字氏名
        private string _kanjiName;
        public string KanjiName
        {
            get { return _kanjiName; }
            set { SetProperty(ref _kanjiName, value); }
        }

        // カナ氏名
        private string _kanaName;
        public string KanaName
        {
            get { return _kanaName; }
            set { SetProperty(ref _kanaName, value); }
        }

        // 生年月日
        private DateTime _birthDate;
        public DateTime  BirthDate
        {
            get { return _birthDate; }
            set { SetProperty(ref _birthDate, value); }
        }

        // 性別
        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }

        public PatientInfo()
        {

        }
    }
}
