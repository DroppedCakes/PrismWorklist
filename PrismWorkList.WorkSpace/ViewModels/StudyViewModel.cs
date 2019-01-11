using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Reactive.Bindings;
using PrismWorkList.Infrastructure.Models;

namespace PrismWorkList.WorkSpace.ViewModels
{
    public class StudyViewModel : BindableBase
    {
        /// <summary>
        ///
        /// </summary>
        public StudyOrder Study { get; }

        public StudyViewModel(StudyOrder study)
        {
            this.Study = Study;
        }

        /// <summary>
        /// オーダ番号
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string OrderNumber => this.Study.OrderNumber;

        /// <summary>
        /// モダリティ
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string ExaminationCode => this.Study.ExaminationTypeCode;

        /// <summary>
        /// 患者生年月日
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public DateTime BirthDate => this.Study.Patient.BirthDate;

        /// <summary>
        /// 患者ID
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string PatientId => this.Study.Patient.PatientID;

        /// <summary>
        /// 患者漢字氏名
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string PatientNameKanji => this.Study.Patient.KanjiName;

        /// <summary>
        /// 患者半角ｶﾅ氏名
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string PatientNameKana => this.Study.Patient.KanaName;

        /// <summary>
        /// 患者性別
        /// F, M, O
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string PatientGender => this.Study.Patient.Gender;

        /// <summary>
        /// 検査日付
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public DateTime ExaminationDate => this.Study.ExaminationDate;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="study"></param>
        /// <returns></returns>
        public static StudyViewModel Create(StudyOrder study)
        {
            var Patient = study.Patient;
            var retv = new StudyViewModel(study);

            return retv;
        }

    }
}
