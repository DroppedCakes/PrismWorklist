using NLog;
using Prism.Mvvm;
using Prism.Regions;
using PrismWorkList.Infrastructure;
using PrismWorkList.Infrastructure.Models;
using PrismWorkList.WorkSpace.Views;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reactive.Linq;

namespace PrismWorkList.Login.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        /// <summary>
        /// logger
        /// </summary>
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// コンストラクタでインジェクション
        /// </summary>
        private IRegionManager RegionManager;

        // Model
        private RisUser RisUser;

        /// <summary>
        /// デザイン用コンストラクタ
        /// </summary>
        public LoginViewModel()
        {
        }

        /// <summary>
        /// 本番用コンストラクタ
        /// </summary>
        public LoginViewModel(IRegionManager regionManager, ITransactionContext transactionContext)
        {
            RegionManager = regionManager;

            RisUser = new RisUser(transactionContext);

            // M->VMの接続
            UserId = RisUser.ObserveProperty(x => x.UserId)
                .ToReactiveProperty()
                .SetValidateAttribute(() => UserId);

            // VM->Mの接続
            UserId
                // エラーが無い時
                .Where(_ => !UserId.HasErrors)
                // モデルに設定
                .Subscribe(x => RisUser.UserId = x);

            // パスワードM->VM
            Password = RisUser.ObserveProperty(x => x.Password)
                .ToReactiveProperty()
                .SetValidateAttribute(() => Password);

            // パスワードVM->M
            Password
                .Where(x => !Password.HasErrors)
                .Subscribe(x => RisUser.Password = x);

            // 入力項目に不備が無ければ押せるコマンド
            LoginCommand = new[]
            {
                UserId.Select(_=>!UserId.HasErrors),
                Password.Select(_=>!Password.HasErrors)
            }
            .CombineLatestValuesAreAllTrue()
            .ToReactiveCommand();

            // ログイン認証を試す
            LoginCommand.Subscribe(_ => RisUser.TryLogin());

            // ログイン認証が通ればTrue
            CanLogin = RisUser.ObserveProperty(x => x.CanLogin)
                .ToReadOnlyReactiveProperty();

            // CanLogin値が変われば、画面遷移する
            CanLogin.Subscribe(_ => Navigation());
        }

        #region ログイン動作
        [Required(ErrorMessage = "UserIDを入力してください")]
        public ReactiveProperty<string> UserId { get; private set; }

        [Required(ErrorMessage = "Passwordを入力してください")]
        public ReactiveProperty<string> Password { get; private set; }

        public ReadOnlyReactiveProperty<bool> CanLogin { get; private set; }

        /// <summary>
        /// 認証コマンド
        /// </summary>
        public ReactiveCommand LoginCommand { get; private set; }

        /// <summary>
        /// 画面遷移コマンド
        /// </summary>
        public ReactiveCommand NavigationCommand { get; private set; }

        /// <summary>
        /// 画面遷移メソッド
        /// </summary>
        private void Navigation()
        {
            var param = new NavigationParameters();
            param.Add("CurrentUser", UserId.Value);

            //　ワークリスト画面に遷移
            RegionManager.RequestNavigate("ContentRegion", nameof(ViewWorkSpace),param);
        }

        #endregion ログイン動作

    }
}
