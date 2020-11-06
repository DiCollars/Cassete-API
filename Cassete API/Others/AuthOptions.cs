using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Cassete_API.Others
{
    public class AuthOptions 
    {
        public const string ISSUER = "Master"; 
        public const string AUDIENCE = "Slave"; 
        const string KEY = "doyouwannabeawinner?no,imsorry.honestlyiam";  
        public const int LIFETIME = 5; 

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
