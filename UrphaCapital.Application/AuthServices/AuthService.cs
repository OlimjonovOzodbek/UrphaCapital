﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UrphaCapital.Application.ViewModels;
using UrphaCapital.Domain.Entities.Auth;

namespace UrphaCapital.Application.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenModel GenerateToken(Student user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Secret"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_configuration["JWTSettings:Expire"]!);

            string ids = "";

            foreach (var a in user.CourseIds)
            {
                ids += a.ToString() + " ";
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim("UserId", user.Id.ToString()),
                new Claim("Title", user.FullName),
                new Claim("Phone", user.PhoneNumber),
                new Claim("ids", ids),
                new Claim("Address", user.Address),
                new Claim("Email", user.Email),
                new Claim("Role", user.Role!),
                new Claim(ClaimTypes.UserData, ids)
            };



            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWTSettings:ValidIssuer"],
                audience: _configuration["JWTSettings:ValidAudence"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            var response = new TokenModel()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                isSuccess = true,
                Message = "Token generated successfully!"
            };

            return response;
        }

        public TokenModel GenerateToken(Admin user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Secret"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_configuration["JWTSettings:Expire"]!);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim("Id", user.Id.ToString()),
                new Claim("Title", user.Name),
                new Claim("Phone", user.PhoneNumber),
                new Claim("Email", user.Email),
                new Claim("Role", user.Role!)
            };



            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWTSettings:ValidIssuer"],
                audience: _configuration["JWTSettings:ValidAudence"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            var response = new TokenModel()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                isSuccess = true,
                Message = "Token generated successfully!"
            };

            return response;
        }

        public TokenModel GenerateToken(Mentor user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Secret"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_configuration["JWTSettings:Expire"]!);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim("Id", user.Id.ToString()),
                new Claim("Title", user.Name),
                new Claim("Phone", user.PhoneNumber),
                new Claim("Email", user.Email),
                new Claim("Role", user.Role!)
            };



            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWTSettings:ValidIssuer"],
                audience: _configuration["JWTSettings:ValidAudence"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            var response = new TokenModel()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                isSuccess = true,
                Message = "Token generated successfully!"
            };

            return response;
        }
    }
}
