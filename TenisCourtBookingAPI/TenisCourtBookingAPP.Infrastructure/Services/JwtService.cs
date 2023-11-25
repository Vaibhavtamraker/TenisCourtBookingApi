using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Entities;

namespace TenisCourtBookingAPP.Infrastructure.Services
{
    public class JwtService
    {
        public string Key { get; set; }
        public string Duration { get; set; }
        public JwtService(string? Key, string? Duration)
        {
            this.Key = Key ?? "";
            this.Duration = Duration ?? "";
        }
        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Key));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var cliams = new[]
            {
                new Claim("id",user.UserId.ToString()),
                new Claim ("name",user.Name),
                new Claim ("email",user.Email),
                new Claim ("mobileNo",user.MobileNo),
                new Claim("address",user.Address),
                new Claim("gender",user.Gender)
            };

            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: cliams,
                expires: DateTime.Now.AddMinutes(Int32.Parse(this.Duration)),
                signingCredentials: credential
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
