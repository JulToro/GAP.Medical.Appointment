using GAP.Medical.Appointment.Domain.Patients;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GAP.Medical.Appointment.Security.Entities
{
    public class JWToken
    {
        public string GenerateJWTToken(Patient model, string key, string Issuer)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, model.Name + " " + model.LastName),
                new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                new Claim("CreatedDate", model.CreationDate.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var token = new JwtSecurityToken(Issuer,
                Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
