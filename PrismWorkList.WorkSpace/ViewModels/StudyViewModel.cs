using Prism.Commands;
using Prism.Mvvm;
using PrismWorkList.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismWorkList.WorkSpace.ViewModels
{
    public class StudyViewModel : BindableBase
    {
            /// <summary>
            ///
            /// </summary>
            public StudyOrder Study { get; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="study"></param>
            public StudyViewModel(StudyOrder study)
            {
                this.Study = study;
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
            public string Modality { get; private set; }

            /// <summary>
            /// 患者生年月日
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public DateTime PatientBirthDate => this.Study.Patient.BirthDate;

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
            public string PatientNameKana { get; private set; }

            /// <summary>
            /// 患者性別
            /// F, M, O
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public string PatientSex => this.Study.Patient.Gender;

            /// <summary>
            /// 受診日付
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public DateTime PerformedDate => this.Study.ExaminationDate;

            /// <summary>
            ///
            /// </summary>
            /// <param name="study"></param>
            /// <param name="risitems"></param>
            /// <returns></returns>
            public static StudyViewModel Create(StudyOrder study)
            {
                var patient = study.Patient;

                var retv = new StudyViewModel(study);

                return retv;
            }
        }
}
