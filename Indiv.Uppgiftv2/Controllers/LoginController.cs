
using IndProjModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Indiv.Uppgiftv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            if (login.Username == "Admin1001" && login.Password == "123Password")
            {
                var token = GenerateJwtToken();
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken()
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("YourSecretKeyForAuthenticationOfApplication");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", "1") }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "youtCompanyIssuer.com",
                Audience = "youtCompanyIssuer.com"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
    //{
    //    [HttpPost("login")]
    //    public IActionResult Login(LoginDTO login)
    //    {
    //        if (login.Username == "Admin1001" && login.Password == "123Password")
    //        {
    //            var token = GenerateJwtToken();
    //            return Ok(new { token });
    //        }
    //        return Unauthorized();
    //    }

    //    private string GenerateJwtToken()
    //    {
    //        var tokenHandler = new JwtSecurityTokenHandler();
    //        var key = Encoding.UTF8.GetBytes("G7DkUJneKl1Z3YRpQF6sjV8hT3mC9gX5");
    //        var tokenDescriptor = new SecurityTokenDescriptor
    //        {
    //            Subject = new ClaimsIdentity(new[] { new Claim("id", "1") }),
    //            Expires = DateTime.UtcNow.AddHours(1),
    //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
    //            Issuer = "http://localhost",
    //            Audience = "http://localhost"
    //        };
    //        var token = tokenHandler.CreateToken(tokenDescriptor);
    //        return tokenHandler.WriteToken(token);
    //    }
    //}
    //public IActionResult Login(LoginDTO loginDTO)
    //{
    //    try
    //    {
    //        if (string.IsNullOrEmpty(loginDTO.UserID) ||
    //                string.IsNullOrEmpty(loginDTO.Password))
    //            return BadRequest("Username and/or password not specified.");
    //        if (loginDTO.UserID.Equals("Admin1001") && loginDTO.Password.Equals("123Pasword"))
    //        {
    //            var secretKey = new SymmetricSecurityKey
    //                (Encoding.UTF8.GetBytes("thisisasecretkey@123"));

    //            var signinCredentials = new SigningCredentials
    //                (secretKey, SecurityAlgorithms.HmacSha256);

    //            var jwtSecurityToken = new JwtSecurityToken(
    //                issuer: "NaWi",
    //                audience: "https://localhost:7203",
    //                claims: new List<Claim>(),
    //                expires: DateTime.Now.AddMinutes(10),
    //                signingCredentials: signinCredentials
    //                );
    //            Ok(new JwtSecurityTokenHandler()
    //                .WriteToken(jwtSecurityToken));
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        return BadRequest
    //        ("An error occurred in generating the token");
    //    }
    //    return Unauthorized();
    //}


    //[HttpPost, Route("login")]
    //public IActionResult Login(LoginDTO loginDTO)
    //{
    //    try
    //    {
    //        if (string.IsNullOrEmpty(loginDTO.UserID) ||
    //            string.IsNullOrEmpty(loginDTO.Password))
    //        {
    //            return BadRequest("Username and/or password not specified.");
    //        }

    //        if (loginDTO.UserID.Equals("Admin1001") && loginDTO.Password.Equals("123Password"))
    //        {
    //            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisisasecretkey@123"));
    //            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

    //            var jwtSecurityToken = new JwtSecurityToken(
    //                issuer: "NaWi",
    //                audience: "http://localhost:7203",
    //                claims: new List<Claim>(),
    //                expires: DateTime.Now.AddMinutes(10),
    //                signingCredentials: signinCredentials
    //            );

    //            var tokenString = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    //            return Ok(new { Token = tokenString });
    //        }

    //        return Unauthorized();
    //    }
    //    catch (Exception)
    //    {
    //        return BadRequest("An error occurred in generating the token");
    //    }
    //}


