
using IndProjModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Indiv.Uppgiftv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //
    public class LoginController : ControllerBase
    {
        [HttpPost, Route("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                if (string.IsNullOrEmpty(loginDTO.UserID) || 
                        string.IsNullOrEmpty(loginDTO.Password))
                        return BadRequest("Username and/or password not specified.");
                if (loginDTO.UserID.Equals("joydip") && loginDTO.Password.Equals("joydipp123"))
                {
                    var secretKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes("thisisasecretkey@123"));

                    var signinCredentials = new SigningCredentials
                        (secretKey, SecurityAlgorithms.HmacSha256);

                    var jwtSecurityToken = new JwtSecurityToken(
                        issuer: "NaWi",
                        audience: "http://localhost:51398",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials
                        );
                    Ok(new JwtSecurityTokenHandler()
                        .WriteToken(jwtSecurityToken));
                }            
            }
            catch (Exception)
            {
                return BadRequest
                ("An error occurred in generating the token");
            }
            return Unauthorized();
        }
    }
}
