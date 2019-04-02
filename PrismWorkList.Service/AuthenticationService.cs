using Prism.Mvvm;
using PrismWorkList.Infrastructure;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PrismWorkList.Service
{
    public class AuthenticationService : BindableBase, IAuthenticationService
    {
        private readonly UserDao _userDao;

        public AuthenticationService(UserDao userDao)
        {
            _userDao = userDao;
        }

        /// <summary>
        /// Saltサイズ
        /// </summary>
        private const int SALT_SIZE = 24;

        /// <summary>
        /// 
        /// </summary>
        private readonly ITransactionContext _transactionContext;

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
        ///
        /// </summary>
        public void TryLoginAuthorization(string id, string password)
        {
            using (var transaction = _transactionContext.Open())
            {
                var userDao = new UserDao();

                var obteinedUser = userDao.FindByLoginId(_transactionContext.Connection, userId);

                transaction.Complete();

                // ユーザーが存在しなければreturn
                if (obteinedUser == null)
                {
                    Password = "";
                    return;
                }

                var hash_pass = GeneratePasswordHash(Password, obteinedUser.Salt);

                // ハッシュ化したパスワードがDBと一致するか
                if (obteinedUser.Password == hash_pass)
                {
                    CanLogin = true;
                }
                else
                {
                    Password = "";
                }
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
