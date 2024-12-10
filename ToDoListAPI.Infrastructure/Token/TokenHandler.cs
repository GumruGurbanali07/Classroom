
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ToDoListAPI.Application.Token;
using ToDoListAPI.Domain.Entities.Identity;
using C = ToDoListAPI.Application.DTOs;
namespace ToDoListAPI.Infrastructure.Token
{
	public class TokenHandler : ITokenHandler
	{
		private IConfiguration _configuration;

		public TokenHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public Task<C::Token> CreateAccessToken(int second, AppUser appUser)
		{
			C::Token token = new C::Token();

			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
			SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
			token.Expiration = DateTime.UtcNow.AddSeconds(second);
			JwtSecurityToken securityToken = new JwtSecurityToken(
				audience: _configuration["Token:Audience"],
				issuer: _configuration["Token:Issuer"],
				expires: token.Expiration,
				notBefore: DateTime.UtcNow,
				signingCredentials: signingCredentials,
				claims: new List<Claim> { new Claim(ClaimTypes.Name, appUser.UserName) }
			);



			JwtSecurityTokenHandler tokenHandler = new();

			token.AccessToken = tokenHandler.WriteToken(securityToken);

			token.RefreshToken = CreateRefreshToken(); ;


			return Task.FromResult(token);
		}

		public string CreateRefreshToken()
		{
			byte[] number = new byte[32];
			using RandomNumberGenerator random = RandomNumberGenerator.Create();
			random.GetBytes(number);

			return Convert.ToBase64String(number);
		}
	}
}