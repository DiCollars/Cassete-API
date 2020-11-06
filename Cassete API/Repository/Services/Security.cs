using Cassete_API.Repository.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Cassete_API.Others
{
    public class Security : ISecurity
    {
        public string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();

            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }

            return hash;
        }
    }
}
