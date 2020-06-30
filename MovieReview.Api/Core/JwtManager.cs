using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReview.Application.DataTransfer;
using MovieReview.EfDataAccess;
using MovieReview.Implementation.Common;
using MovieReview.Implementation.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Api.Core
{
    public class JwtManager
    {
        private readonly MovieReviewContext _context;
        private readonly TokenValidator _validator;
        public JwtManager(MovieReviewContext context, TokenValidator validator)
        {
            _context = context;
            _validator = validator;

        }

        public string MakeToken(LoginRequestDto request)
        {
            _validator.ValidateAndThrow(request);
            var username = request.Username;
            var password = request.Password;


            var user = _context.Users.Include(u => u.UserUseCases)
                .FirstOrDefault(x => x.Username == username);
            var hashedPassword = user.Password;
            var decryptedPassword = CommonMethods.ConvertToDecrypt(hashedPassword);

            if (decryptedPassword != password || user == null)
            {
                return null;
            }

            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = user.UserUseCases.Select(x => x.UseCaseId),
                Identity = user.Username
            };

            var issuer = "asp_api";
            var secretKey = "ThisIsMyVerySecretKey";
            var claims = new List<Claim> // Jti : "", 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddHours(6),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
