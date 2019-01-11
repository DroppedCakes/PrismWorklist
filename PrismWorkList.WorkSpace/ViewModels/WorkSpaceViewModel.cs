using NLog;
using Prism.Commands;
using Prism.Mvvm;
using PrismWorkList.Infrastructure.Models;
using PrismWorkList.WorkSpace.Helpers;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrismWorkList.WorkSpace.ViewModels
{
    public class WorkSpaceViewModel : BindableBase
    {

        public WorkSpaceViewModel()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        public ReactiveProperty<DateTime> StudyDateSince { get; set; } = new ReactiveProperty<DateTime>();

        /// <summary>
        /// 
        /// </summary>
        public ReactiveProperty<DateTime> StudyDateUntil { get; set; } = new ReactiveProperty<DateTime>();

        #region 再読み込み

      
        #endregion 再読み込み
    }
}
