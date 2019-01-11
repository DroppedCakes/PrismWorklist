using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace PrismWorkList.Infrastructure.Models
{
    public class StudyOrder:BindableBase
    {
        // 一覧で検査が選択されているか
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        // サロゲートキー
        private int _id;
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        // オーダ番号
        private string _orderNumber;
        public string OrderNumber
        {
            get { return _orderNumber; }
            set { SetProperty(ref _orderNumber, value); }
        }

        // 検査日付
        private DateTime _examinationDate;
        public DateTime ExaminationDate
        {
            get { return _examinationDate; }
            set { SetProperty(ref _examinationDate, value); }
        }

        // 処理区分
        private string _processingDivision;
        public string ProcessingDivision
        {
            get { return _processingDivision; }
            set { SetProperty(ref _processingDivision, value); }
        }

        // 患者属性情報のサロゲートキー
        private int _infoId;
        public int InfoId
        {
            get { return _infoId; }
            set { SetProperty(ref _infoId, value); }
        }

        // 検査種別コード
        private string _examinationTypeCode;
        public string ExaminationTypeCode
        {
            get { return _examinationTypeCode; }
            set { SetProperty(ref _examinationTypeCode, value); }
        }

        // 検査種別名称
        private string _examinationTypeName;
        public string ExaminationTypeName
        {
            get { return _examinationTypeName; }
            set { SetProperty(ref _examinationTypeName, value); }
        }

        // コメント
        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetProperty(ref _comment, value); }
        }

        // 検査が従属する患者属性情報
        private PatientInfo _patient;
        public PatientInfo Patient
        {
            get { return _patient; }
            set { SetProperty(ref _patient, value); }
        }
    }
}
 