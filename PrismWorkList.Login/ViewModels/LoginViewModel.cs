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

namespace PrismWorkList.Login.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        /// <summary>
        /// logger
        /// </summary>
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        private string _userId;

        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            get { return this._userId; }
            set { this.SetProperty(ref this._userId, value); }
        }

        private string _password;

        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get { return this._password; }
            set { this.SetProperty(ref this._password, value); }
        }

        #region PasswordChanged

        /// <summary>
        ///
        /// </summary>
        public DelegateCommand<PasswordBox> PasswordChangedCommand { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private DelegateCommand<PasswordBox> CreatePasswordChangedCommand()
        {
            return new DelegateCommand<PasswordBox>(
                this.ExecutePasswordChanged
            );
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="passwordBox"></param>
        private void ExecutePasswordChanged(PasswordBox passwordBox)
        {
            this.Password = passwordBox.Password;
        }

        #endregion PasswordChanged

        #region ログイン動作

        /// <summary>
        ///
        /// </summary>
        public DelegateCommand<PasswordBox> LoginCommand { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private DelegateCommand<PasswordBox> CreateLoginCommand()
        {
            return new DelegateCommand<PasswordBox>(
                this.ExecuteLogin,
                this.CanExecuteLogin
            )
            .ObservesProperty(() => this.UserId)
            .ObservesProperty(() => this.Password);
        }

        /// <summary>
        ///
        /// </summary>
        private void ExecuteLogin(PasswordBox passwordBox)
        {
            var user_id = this.UserId;
            var password = this.Password;

            //  ここでパスワードをクリア
            passwordBox.Password = "";

            try
            {
                if (RisUser.IsPasswordValid(password))
                {
                    //　ワークリスト画面に遷移
                }
                else
                {
                    //　ダイアログ出す
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteLogin(PasswordBox passwordBox)
        {
            return !string.IsNullOrWhiteSpace(this.UserId)
                && !string.IsNullOrWhiteSpace(passwordBox.Password);
        }

        #endregion ログイン動作

        #region 終了

        public DelegateCommand<Button> ExitCommand { get; private set; }
                
        #endregion 終了


        /// <summary>
        /// 
        /// </summary>
        public LoginViewModel()
        {
            this.LoginCommand = this.CreateLoginCommand();
            this.PasswordChangedCommand = this.CreatePasswordChangedCommand();
        }
    }
}
