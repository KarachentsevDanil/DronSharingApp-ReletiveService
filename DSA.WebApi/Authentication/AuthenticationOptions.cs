using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RCS.WebApi.Authentication
{
    public class AuthenticationOptions
    {
        private const string TokenKey = "mysupersecret_secretkey123!";
        
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenKey));
        }
    }
}
