using NLog;
using Prism.Commands;
using Prism.Mvvm;
using PrismWorkList.WorkSpace.Helpers;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrismWorkList.WorkSpace.ViewModels
{
    public class ViewWorkSpaceViewModel : BindableBase
    {
        /// <summary>
        /// ロガー
        /// </summary>
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 一定ポイントで同期させる
        /// </summary>
        private readonly SynchronizationContext _syncer = SynchronizationContext.Current;

        #region 検査一覧

        /// <summary>
        /// 検査一覧
        /// </summary>
        public ObservableCollection<StudyViewModel> Studies { get; private set; } = new ObservableCollection<StudyViewModel>();

        public ReactiveProperty<DateTime> StudyDateSince { get; set; } = new ReactiveProperty<DateTime>(DateTime.Now);

        public ReactiveProperty<DateTime> StudyDateUntil { get; set; } = new ReactiveProperty<DateTime>(DateTime.Now);

        // 検索条件クリアコマンド
        public ReactiveCommand SearchCriteriaClearCommand { get; } = new ReactiveCommand();

        // ワークリスト更新コマンド
        public ReactiveCommand StudiesReloadCommand { get; } = new ReactiveCommand();

        /// <summary>
        /// 検索条件クリア
        /// </summary>
        private void CriteriaClear()
        {
            this.StudyDateSince.Value = DateTime.Now;
            this.StudyDateUntil.Value = DateTime.Now;
        }

        /// <summary>
        /// 検査を再読み込み
        /// </summary>
        private async void StudiesReload()
        {
            //this.Studies.Clear();

            //await Task.Factory.StartNew(
            //    () =>
            //    {
            //        var loader = new StudyLoader();

            //        foreach (var study in loader.FetchWorkList())
            //        {
            //            this._syncer.Post(this.AddStudy, study);
            //        }
            //    }
            //    );
        }

        /// <summary>
        /// 検査を追加
        /// </summary>
        /// <param name="study"></param>
        private void AddStudy(object study)
        {
            this.AddStudy((StudyViewModel)study);
        }

        private void AddStudy(StudyViewModel study)
        {
            this.Studies.Add(study);
        }
                
        #endregion 検査一覧

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ViewWorkSpaceViewModel()
        {
            // クリア
            this.SearchCriteriaClearCommand.Subscribe( _=>this.CriteriaClear());

            this.StudiesReloadCommand.Subscribe(async _ => await Task.Run(() =>
            {
                this.StudiesReload();
            }));
        }


    }
}
