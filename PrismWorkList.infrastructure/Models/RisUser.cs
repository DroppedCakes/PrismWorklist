using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrismWorkList.Infrastructure.Models
{
    public class RisUser
    {
        /// <summary>
        /// Saltサイズ
        /// </summary>
        private const int SALT_SIZE = 24;

        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 未実装
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsPasswordValid(string password)
        {
            var salt = GenerateSalt();

            var passwordHash = GeneratePasswordHash(password, salt);

            var retv = true;

            return retv;
        }

        public static string GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();

            var buff = new byte[SALT_SIZE];

            rng.GetBytes(buff);

            return BitConverter.ToString(buff);
        }
        
        public  static string GeneratePasswordHash(string password,string salt)
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
