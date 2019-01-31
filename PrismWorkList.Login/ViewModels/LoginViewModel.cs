using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using System.Windows.Controls;
using PrismWorkList.Infrastructure;
using PrismWorkList.Infrastructure.Models;
using PrismWorkList.WorkSpace.Views;
using Prism.Ioc;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Linq;
using System.ComponentModel.DataAnnotations;
using PrismWorkList.Login.Helper;
using System.Data;

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
            this.RegionManager = regionManager;

            this.RisUser = new RisUser(transactionContext);

            // M->VMの接続
            this.UserId = this.RisUser.ObserveProperty(x => x.UserId)
                .ToReactiveProperty()
                .SetValidateAttribute(() => this.UserId);

            // VM->Mの接続
            this.UserId
                // エラーが無い時
                .Where(_ => !this.UserId.HasErrors)
                // モデルに設定
                .Subscribe(x => this.RisUser.UserId = x);

            // パスワードM->VM
            this.Password = this.RisUser.ObserveProperty(x => x.Password)
                .ToReactiveProperty()
                .SetValidateAttribute(() => this.Password);

            // パスワードVM->M
            this.Password
                .Where(x => !this.Password.HasErrors)
                .Subscribe(x => this.RisUser.Password = x);

            // 入力項目に不備が無ければ押せるコマンド
            this.LoginCommand = new[]
            {
                this.UserId.Select(_=>!this.UserId.HasErrors),
                this.Password.Select(_=>!this.Password.HasErrors)
            }
            .CombineLatestValuesAreAllTrue()
            .ToReactiveCommand();

            // ログイン認証を試す
            this.LoginCommand.Subscribe(_ => RisUser.TryLogin());

            // ログイン認証が通ればTrue
            this.CanLogin = this.RisUser.ObserveProperty(x => x.CanLogin)
                .ToReadOnlyReactiveProperty();

            // CanLogin値が変われば、画面遷移する
            this.CanLogin.Subscribe(_ => Navigation());
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
            //　ワークリスト画面に遷移
            RegionManager.RequestNavigate("ContentRegion", nameof(ViewWorkSpace));
        }

        #endregion ログイン動作

    }
}
