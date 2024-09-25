using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace jwttest.Models
{
    public class jwtService
    {
        public string GenerateJSONWebToken()
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond0007_MynameisJamesBond007"));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: "https://www.yogihosting.com",
                audience: "dotnetclient",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials


                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void setJWTCookie(string token)
        {
            
        }

    }
}
