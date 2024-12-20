using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Application.Token;
using T = ToDoListAPI.Infrastructure.Token;
namespace ToDoListAPI.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureServices(this IServiceCollection services)
		{
			services.AddScoped<ITokenHandler, T.TokenHandler>();
			services.AddScoped<IMailService, IMailService>();

		}
	}
}
