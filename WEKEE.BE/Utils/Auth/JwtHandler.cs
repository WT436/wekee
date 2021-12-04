﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using Utils.Auth.Dtos;

namespace Utils.Auth
{
    public class JwtHandler : IJwtHandler
    {
        private readonly ExternalClientJsonConfiguration _settings;
        public JwtHandler(IOptions<ExternalClientJsonConfiguration> setting)
        {
            _settings = setting.Value;
        }

        public JwtResponse CreateToken(JwtCustomClaims claims)
        {
            var privateKey = _settings.RsaPrivateKey.ToByteArray();
            using RSA rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(privateKey, out _);
            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };
            var now = DateTime.Now;
            var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();
            var jwt = new JwtSecurityToken(
                audience: _settings.Audience,
                issuer: _settings.Issuer,
                claims: new Claim[] {
                    new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString(), ClaimValueTypes.Integer64),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(nameof(claims.Id),claims.Id.ToString()),
                    new Claim(nameof(claims.Account_User),claims.Account_User.ToString()),
                    new Claim(nameof(claims.Email),claims.Email.ToString()),
                    new Claim(nameof(claims.Ip),claims.Ip.ToString())
                },
                notBefore: now,
                expires: now.AddDays(10),
                signingCredentials: signingCredentials
            );
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JwtResponse
            {
                Token = token
            };
        }

        public JwtCustomClaims ReadFullInfomation(string token)
        {
            JwtCustomClaims infoToken = new JwtCustomClaims();
            if (!string.IsNullOrEmpty(token) && ValidateToken(token))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                infoToken.Id = Convert.ToInt32(securityToken.Claims.First(claim => claim.Type == nameof(infoToken.Id)).Value);
                infoToken.Account_User = securityToken.Claims.First(claim => claim.Type == nameof(infoToken.Account_User)).Value;
                infoToken.Email = securityToken.Claims.First(claim => claim.Type == nameof(infoToken.Email)).Value;
                infoToken.Ip = securityToken.Claims.First(claim => claim.Type == nameof(infoToken.Ip)).Value;
            }
            return infoToken;
        }

        private bool ValidateToken(string token)
        {
            var publicKey = _settings.RsaPublicKey.ToByteArray();
            using RSA rsa = RSA.Create();
            rsa.ImportRSAPublicKey(publicKey, out _);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _settings.Issuer,
                ValidAudience = _settings.Audience,
                IssuerSigningKey = new RsaSecurityKey(rsa),

                CryptoProviderFactory = new CryptoProviderFactory()
                {
                    CacheSignatureProviders = false
                }
            };
            try
            {
                var handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, validationParameters, out var validatedSecurityToken);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}