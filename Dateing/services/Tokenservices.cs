using Dateing.Interfaces;
using Dateing.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dateing.services
{
    public class Tokenservices : ITokenservices
    {
        private readonly SymmetricSecurityKey key;
        public Tokenservices(IConfiguration config)
        {
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public string GetToken(AppUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.UserName),
            };
            var crds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var t = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires=DateTime.Now.AddDays(1),
                SigningCredentials=crds,
            };
            var tokenHandel = new JwtSecurityTokenHandler();
            var token = tokenHandel.CreateToken(t);
            return tokenHandel.WriteToken(token);
        }
    }
}
