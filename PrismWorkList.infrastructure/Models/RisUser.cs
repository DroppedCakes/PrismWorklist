using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
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
        /// 
        /// </summary>
        private readonly IDbConnection _dbConnection;
 
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
        /// コンストラクタ
        /// </summary>
         public RisUser(IDbConnection dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        /// <summary>
        /// 未実装
        /// </summary>
        public void TryLogin()
        {
            try { 
            this._dbConnection.Open();

            var userDao = new UserDao(this._dbConnection);

            var obteinedUser = userDao.FindByLoginId(this.userId);

             if (obteinedUser == null)
                {
                    this.Password = "";
                    return;
                }

                var hash_pass = GeneratePasswordHash(Password, obteinedUser.Salt);

            if (obteinedUser.Password ==hash_pass)
            {
                this.CanLogin = true;
            }
            else
            {
                this.Password = "";
            }

            }
            finally
            {
                this._dbConnection.Close();
            }
        }

        /// <summary>
        /// 乱数からソルトを作成
        /// </summary>
        /// <returns></returns>
        public string GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();

            var buff = new byte[SALT_SIZE];

            rng.GetBytes(buff);

            return BitConverter.ToString(buff);
        }

        /// <summary>
        /// パスワードをハッシュ化する
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string GeneratePasswordHash(string password, string salt)
        {
            var concatPass = String.Concat(password, salt);

            var encoder = new UTF8Encoding();

            var buff = encoder.GetBytes(concatPass);

            var csp = new SHA256CryptoServiceProvider();

            var retv = csp.ComputeHash(buff);

            return BitConverter.ToString(retv);
        }
    }
}

    

