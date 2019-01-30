using NLog;
using Prism.Mvvm;
using Prism.Regions;
using PrismWorkList.Domain;
using Reactive.Bindings;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PrismWorkList.Infrastructure.Models;
using System.ComponentModel;
using System.Windows.Data;

namespace PrismWorkList.WorkSpace.ViewModels
{
    public class ViewWorkSpaceViewModel : BindableBase
    {
        /// <summary>
        /// ロガー
        /// </summary>
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// 検査取得サービス
        /// </summary>
        private readonly IStudiesService _studiesService;

        /// <summary>
        /// AutoMapping
        /// ViewOrderPatient→StudyVMに詰め替え
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// 一定ポイントで同期させる
        /// </summary>
        private readonly SynchronizationContext _syncer = SynchronizationContext.Current;

        #region 検索条件

        /// <summary>
        /// 
        /// </summary>
        public ReactiveProperty<string> PatientID { get; set; } = new ReactiveProperty<string>();

        /// <summary>
        /// 
        /// </summary>
        public ReactiveProperty<DateTime> StudyDateSince { get; set; } = new ReactiveProperty<DateTime>(DateTime.Now);

        /// <summary>
        /// 
        /// </summary>
        public ReactiveProperty<DateTime> StudyDateUntil { get; set; } = new ReactiveProperty<DateTime>(DateTime.Now);

        /// <summary>
        /// 検索条件クリアコマンド
        /// </summary>
        public ReactiveCommand SearchCriteriaClearCommand { get; } = new ReactiveCommand();

        /// <summary>
        /// 検索条件クリア
        /// </summary>
        private void CriteriaClear()
        {
            this.StudyDateSince.Value = DateTime.Now;
            this.StudyDateUntil.Value = DateTime.Now;
            this.PatientID.Value = "";
        }
        #endregion 検索条件

        #region 検査読み込み

        /// <summary>
        /// 検査一覧
        /// </summary>
        public ObservableCollection<StudyViewModel> Studies { get; } = new ObservableCollection<StudyViewModel>();

        /// <summary>
        /// フィルターやソート機能を提供
        /// </summary>
        public ICollectionView StudiesView { get; }

        // ワークリスト更新コマンド
        public ReactiveCommand StudiesReloadCommand { get; } = new ReactiveCommand();

        /// <summary>
        /// 検査をクリアする
        /// </summary>
        private void StudiesClear()
        {
            this.Studies.Clear();
        }

        /// <summary>
        /// 検査を再読み込み
        /// </summary>
        private async void StudiesReload(DateTime since,DateTime until)
        {
            this.StudiesClear();

            await Task.Factory.StartNew(
                () =>
                {
                    foreach (var study in _studiesService.FetchOrderPatients(since.Date.ToString(),until.Date.ToString()))
                    {
                        this._syncer.Post(this.AddStudy,study);
                    }
                }
                );
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="study"></param>
        private void AddStudy(object study)
        {
            this.AddStudy(_mapper.Map<StudyViewModel>(study));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="study"></param>
        private void AddStudy(StudyViewModel study)
        {
            this.Studies.Add(study);
        }

        #endregion 検査読み込み

        /// <summary>
        /// デザイン用コンストラクタ
        /// </summary>
        public ViewWorkSpaceViewModel()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ViewWorkSpaceViewModel(IRegionManager regionManager, IStudiesService studiesService)
        {
            // DI
            this._regionManager = regionManager;
            this._studiesService = studiesService;

            this.StudiesView = CollectionViewSource.GetDefaultView(this.Studies);

            // Mapするモデルの設定
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderPatientView, StudyViewModel>();
            });
            // Mapperを作成
           this._mapper = config.CreateMapper();

            // 検索条件クリアコマンド
            this.SearchCriteriaClearCommand.Subscribe( _=>this.CriteriaClear());

            // 再読み込みコマンド
            this.StudiesReloadCommand.Subscribe(_ => this.StudiesReload(StudyDateSince.Value,StudyDateUntil.Value));
        }

    }
}
