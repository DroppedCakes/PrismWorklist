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
            this.StudiesReloadCommand = new DelegateCommand(
                this.ExecuteStudiesReload, () => this.CanReload)
                .ObservesProperty(() => this.CanReload);
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

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<StudyOrder> Studies { get; } = new ObservableCollection<StudyOrder>();

        #region 再読み込み

        /// <summary>
        ///
        /// </summary>
        private bool _canReload = true;

        /// <summary>
        ///
        /// </summary>
        public bool CanReload
        {
            get { return this._canReload; }
            set { this.SetProperty(ref this._canReload, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool _canNavigate;

        /// <summary>
        /// 
        /// </summary>
        public bool CanNavigate
        {
            get { return _canNavigate; }
            set { SetProperty(ref _canNavigate, value); }
        }

        /// <summary>
        ///
        /// </summary>
        public DelegateCommand StudiesReloadCommand { get; }

        /// <summary>
        ///
        /// </summary>
        private void ClearStudies()
        {
            this.Studies.Clear();
        }

        /// <summary>
        ///
        /// </summary>
        private void ExecuteStudiesReload()
        {
            try
            {
                this.Studies.Clear();

                this.CanNavigate = false;
                this.CanReload = false;

                var loader = new StudyLoader();

                foreach (var study in loader.FetchWorkList())
                {
                    this.AddStudy(study);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            finally
            {
                this.CanReload = true;
                this.CanNavigate = true;
            }
        }

        private void AddStudy(StudyOrder study)
        {
            this.Studies.Add(study);
        }
        #endregion 再読み込み
    }
}
