using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ReservationApiCRUD.Models
{
    public class JwtService
    {
     
        public string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond0007_MynameisJamesBond007"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: "https://www.yogihosting.com",
            audience: "dotnetclient",
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    
        public void SetJWTCookie(string token)
        {
           
        }
    }
}
