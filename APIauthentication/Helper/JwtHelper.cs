using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIauthentication.Helper
{
    public class JwtHelper
    {
        private static readonly string SecretKey = "GrhugP5ibpcPq5APMrR2XTWqaX23tor3gY49cD3DpEDL3RoQEqtd8SXT0dpkAcD"; 
        

        public static string GenerateToken(string username, string role)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(ClaimTypes.Role, role),
            new Claim("scope", role == "admin" ? "b_game vip_chararacter_personalize" : "b_game")
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
