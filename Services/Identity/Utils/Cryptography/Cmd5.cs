using System;
using System.Security.Cryptography;
using System.Text;

namespace Identity.Utils.Cryptography
{
	public class Cmd5
	{
        public Cmd5() { }

        public static string getMD5(string strData)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(strData));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMd5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            return sb.ToString().ToUpper();
        }

        public static string hashArray(byte[] array)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMd5 = md5.ComputeHash(array);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMd5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            return sb.ToString().ToUpper();
        }

        public static string getHash(string param)
        {
            throw new NotImplementedException();
        }
    }
}
