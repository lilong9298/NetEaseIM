using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NetEaseIM.Model {
    public class NetEaseIMServerSetting {
        public NetEaseIMServerSetting(string appkey, string appsecret) {
            AppKey = appkey;
            AppSecret = appsecret;
            Random random = new Random();
            Nonce = random.Next(1000000, 9999999).ToString();
            DateTime BaseTime = new DateTime(1970, 1, 1);
            Curtime = ((DateTime.Now.Ticks - BaseTime.Ticks) / 10000000 - 8 * 60 * 60).ToString();
        }
        /// <summary>
        /// App Key
        /// </summary>
        public string AppKey;

        /// <summary>
        /// 密钥
        /// </summary>
        public string AppSecret;

        public string Nonce;


        public string Curtime;
        public string CheckSum => GetCheckSum(AppSecret, Nonce, Curtime);

        // 计算并获取CheckSum
        private static string GetCheckSum(string appSecret, string nonce, string curTime) {
            string str_sha1_in = appSecret + nonce + curTime;
            byte[] bytes_sha1_in = UTF8Encoding.UTF8.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = SHA1.Create().ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "");
            return str_sha1_out.ToLower();
        }
    }
}
