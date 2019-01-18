﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrismWorkList.Infrastructure.Models
{
    public class RisUser : BindableBase
    {
        /// <summary>
        /// Saltサイズ
        /// </summary>
        private const int SALT_SIZE = 24;

        /// <summary>
        /// ユーザーID
        /// </summary>
        private string userId;
        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        /// <summary>
        /// パスワード
        /// </summary>
        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        /// <summary>
        /// 認証結果
        /// </summary>
        private bool canLogin;
        public bool CanLogin
        {
            get { return canLogin; }
            set { SetProperty(ref canLogin, value); }
        }

        /// <summary>
        /// 未実装
        /// </summary>
        public void TryLogin()
        {
            //var salt = GenerateSalt();

            //var passwordHash = GeneratePasswordHash(Password, salt);

            if (UserId == "alice")
            {
                this.CanLogin = true;
            }
            else
            {
                this.Password = "";
                this.CanLogin = false;
            }
        }
    }
}

        //public string GenerateSalt()
        //{
        //    var rng = new RNGCryptoServiceProvider();

        //    var buff = new byte[SALT_SIZE];

        //    rng.GetBytes(buff);

        //    return BitConverter.ToString(buff);
        //}
        
        //public string GeneratePasswordHash(string password,string salt)
        //{
        //    var concatPass = String.Concat(password, salt);

        //    var encoder = new UTF8Encoding();

        //    var buff = encoder.GetBytes(concatPass);

        //    var csp = new SHA256CryptoServiceProvider();

        //    var retv = csp.ComputeHash(buff);

        //    return BitConverter.ToString(retv);
        //} 

