using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using NewPlay.Domain.Models;
using NewPlay.Domain.Interfaces;
using NewPlay.Infrastructure.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace NewPlay.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public object Login([FromBody] User user){
            try {
                //só gerar token apenas para usuários que estiverem na base
                var Claims = new List<Claim>{
                    new Claim("type", user.Role)
                };

                var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));

                var Token = new JwtSecurityToken(
                    "http://localhost:5000/",
                    "http://localhost:5000/",
                    Claims,
                    expires: DateTime.Now.AddDays(30.0),
                    signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256)
                );

                return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(Token));
            } catch(Exception error){
                throw error;
            }
        }
    }
}