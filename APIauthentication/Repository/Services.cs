using AuthenticationAPI.Models;
using Microsoft.IdentityModel.Tokens;
//using Org.BouncyCastle.Crypto.Parameters;
//using Org.BouncyCastle.OpenSsl;
//using Org.BouncyCastle.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationAPI.Repository
{
    public class Services
    {
        public Services() { }



        public List<User> _users = new List<User>
        {
        new User { Username = "player1", Password = "password1", Role = "player", Regions = new List<string> { "b_game" } },
        new User { Username = "admin1", Password = "password2", Role = "admin", Regions = new List<string> { "b_game", "vip_character_personalize" } }
        };



        public Object jwtTokenGeneration(userLogin userdata)
        {
            //string token = string.Empty;
            var tokenHandler = new JwtSecurityTokenHandler();

            //string key = Directory.GetCurrentDirectory() + @"\PublicKey\key.pem";

            //string keyData = File.ReadAllText(key);
            //string keystring = File.ReadAllText(key);

            var keydata = Encoding.ASCII.GetBytes("GrhugP5ibpcPq5APMrR2XTWqaX23tor3gY49cD3DpEDL3RoQEqtd8SXT0dpkAcD");

            //string publicKeytext = takepublickey(keyData);

            //RSAParameters? rsaparms = getkey(publicKeytext);

            var user = _users.SingleOrDefault(x => x.Username == userdata.Username && x.Password == userdata.Password);
            

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("regions", string.Join(",", user.Regions))
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keydata), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return (new
            {
                Token = tokenString,
                Username = user.Username,
                Role = user.Role,
                Regions = user.Regions
            });


        }


        #region commentedcode

        //private string takepublickey(string text)
        //{
        //    int start = text.IndexOf("-----BEGIN PRIVATE KEY-----");
        //    if (start == -1) return null;
        //    string strvalue = text.Remove(0,start);
        //    int end = text.IndexOf("-----END PRIVATE KEY-----");
        //    if (end == -1) return null;
        //    strvalue = strvalue.Remove(end) + "-----END PRIVATE KEY-----";
        //    return strvalue;
        //}

        //private RSAParameters? getkey(string text)
        //{
        //    try
        //    {
        //        var privatekeypem = new StringReader(text);
        //        var privatekeyreader = new PemReader(privatekeypem);

        //        var key = privatekeyreader.ReadObject();

        //        return DotNetUtilities.ToRSAParameters(key as RsaPrivateCrtKeyParameters);

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        #endregion

    }
}
