using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Identity;
using ToDoListAPI.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ToDoListAPI.Application.Repository;
using ToDoListAPI.Persistence.Repository;

namespace ToDoListAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));
			services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();
			services.AddScoped<IStudentReadRepository,StudentReadRepository>();
			services.AddScoped<IStudentWriteRepository,StudentWriteRepository>();
			services.AddScoped<ITaskReadRepository,TaskReadRepository>();
			services.AddScoped<ITaskWriteRepository,TaskWriteRepository>();
			services.AddScoped<ITeacherReadRepository,TeacherReadRepository>();
			services.AddScoped<ITeacherWriteRepository, TeacherWriteRepository>();
		}
	}
}
