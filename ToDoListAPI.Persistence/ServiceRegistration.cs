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
using ToDoListAPI.Application.Services;
using ToDoListAPI.Persistence.Services;
using ToDoListAPI.Application.Services.Roles;
using ToDoListAPI.Persistence.Services.Roles;
using Microsoft.Extensions.Options;

namespace ToDoListAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));
			services.AddIdentity<AppUser, AppRole>(options =>
			{
				options.Password.RequiredLength = 6;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = true;
				options.Password.RequireDigit = true;
			})
				.AddRoleManager<RoleManager<AppRole>>()
				.AddEntityFrameworkStores<AppDbContext>();


			services.AddScoped<IStudentTeacherWriteRepository,StudentTeacherWriteRepository>();
			services.AddScoped<IStudentTeacherReadRepository,StudentTeacherReadRepository>();
			services.AddScoped<IStudentReadRepository,StudentReadRepository>();
			services.AddScoped<IStudentWriteRepository,StudentWriteRepository>();
			services.AddScoped<ITaskReadRepository,TaskReadRepository>();
			services.AddScoped<ITaskWriteRepository,TaskWriteRepository>();
			services.AddScoped<ITeacherReadRepository,TeacherReadRepository>();
			services.AddScoped<ITeacherWriteRepository, TeacherWriteRepository>();
			services.AddScoped<IAppUserService, AppUserService > ();
			services.AddScoped<ITeacherService,TeacherService>();
			services.AddScoped<IStudentService, StudentService>();
			services.AddScoped<ITaskService, TaskService>();
			services.AddScoped<IRoleService,RoleService>();
			services.AddScoped<IAuthService,AuthService>();

		}
	}
}
