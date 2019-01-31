using AutoMapper;
using MaterialDesignThemes.Wpf;
using NLog;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismWorkList.Infrastructure.Models;
using PrismWorkList.Service;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PrismWorkList.WorkSpace.ViewModels
{
    public class ViewWorkSpaceViewModel : BindableBase
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<GenderType> Genders { get; private set; }

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
        private readonly IMapper _studyMapper;

        /// <summary>
        /// 一定ポイントで同期させる
        /// </summary>
        private readonly SynchronizationContext _syncer = SynchronizationContext.Current;

        #region 初期読込
        /// <summary>
        /// 
        /// </summary>
        public ICommand InitializeCommand => new DelegateCommand(OnInitialize);

        /// <summary>
        /// 
        /// </summary>
        private void OnInitialize()
        {
            // Mapするモデルの設定
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Gender, GenderType>();
            });
            // Mapperを作成
            var genderMapper = config.CreateMapper();
            
            Genders = _studiesService.GetGenders()
                .Select(genderMapper.Map<GenderType>)
                .ToList()
                .OrderBy(x=>x.Code);

            LoadStudies();

            AddSnackBarMessage($"{DateTime.Now.Date.ToString("yyyyMMdd")}：ログインしました");
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadStudies()
        {

        }

        #endregion 初期読込

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

        /// <summary>
        ///  ワークリスト更新コマンド
        /// </summary>
        public ReactiveCommand StudiesReloadCommand { get; } = new ReactiveCommand();

        /// <summary>
        /// 検査をクリアする
        /// </summary>
        private void StudiesClear()
        {
            this.Studies.Clear();
        }

        /// <summary>
        /// 初期読込
        /// </summary>
        private async void CurrentDateSrudiesLoad(DateTime currentDate)
        {
            await Task.Factory.StartNew(
            () =>
            {
                foreach (var study in _studiesService.FetchOrderPatientsCurrentDay(currentDate.Date.ToString()))
                {
                    this._syncer.Post(this.AddStudy, study);
                }
            }
            );
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
            this.AddStudy(_studyMapper.Map<StudyViewModel>(study));
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

        #region SnackBar
        /// <summary>
        /// 
        /// </summary>
        public SnackbarMessageQueue SnackBarMessageQueue { get; private set; } = new SnackbarMessageQueue();

        /// <summary>
        /// 
        /// </summary>
        public ReactiveCommand ShowSnackBarCommand { get; } = new ReactiveCommand();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void AddSnackBarMessage(string value)
        {
            this.SnackBarMessageQueue.Enqueue(value);
        }

        #endregion SnackBar

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
           this._studyMapper = config.CreateMapper();

            // 検索条件クリアコマンド
            this.SearchCriteriaClearCommand.Subscribe( _=>this.CriteriaClear());

            // 再読み込みコマンド
            this.StudiesReloadCommand.Subscribe(_ => this.StudiesReload(StudyDateSince.Value,StudyDateUntil.Value));

            this.ShowSnackBarCommand.Subscribe(_ => this.AddSnackBarMessage(DateTime.Now.ToString()));
        }

    }
}
