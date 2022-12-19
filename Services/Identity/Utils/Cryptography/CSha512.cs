using System;
using System.Security.Cryptography;
using System.Text;

namespace Identity.Utils.Cryptography
{
	public class CSha512
	{
		public CSha512()
		{
		}
        public static string getCSha512(string strData)
        {
            var message = Encoding.UTF8.GetBytes(strData);
            using (var alg = SHA512.Create())
            {
                string hex = "";

                var hashValue = alg.ComputeHash(message);
                foreach (byte x in hashValue)
                {
                    hex += String.Format("{0:x2}", x);
                }
                return hex.ToString().ToUpper();
            }

        }
    }

}

