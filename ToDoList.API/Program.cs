using ToDoListAPI.Persistence;

using FluentValidation;
using ToDoListAPI.Infrastructure.Filter;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using ToDoListAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
	.AddFluentValidation(v => v
		.RegisterValidatorsFromAssemblyContaining<LoginStudentValidator>()
		.RegisterValidatorsFromAssemblyContaining<RegisterStudentValidator>()
		.RegisterValidatorsFromAssemblyContaining<CreateGradeValidator>()
		.RegisterValidatorsFromAssemblyContaining<UpdateGradeValidator>()
		.RegisterValidatorsFromAssemblyContaining<CreateStudentTaskValidator>()
		.RegisterValidatorsFromAssemblyContaining<UpdateStudentTaskValidator>()
		.RegisterValidatorsFromAssemblyContaining<CreateTaskValidator>()
		.RegisterValidatorsFromAssemblyContaining<UpdateTaskValidator>()
		.RegisterValidatorsFromAssemblyContaining<LoginTeacherValidator>()
		.RegisterValidatorsFromAssemblyContaining<RegisterTeacherValidator>()
		.RegisterValidatorsFromAssemblyContaining<UpdateTeacherValidator>())
	.ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer("Admin", options =>
   {
	   options.TokenValidationParameters = new()
	   {
		   ValidateAudience =true,
		   ValidateIssuer =true,
		   ValidateLifetime =true,
		   ValidateIssuerSigningKey =true,
		   ValidAudience = builder.Configuration["Token:Audience"],
		   ValidIssuer = builder.Configuration["Token:Issuer"],
		   IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
		   LifetimeValidator=(notBefore,expires,securityToken,validationParameters)=>expires!=null?expires>DateTime.UtcNow:false,
		   NameClaimType=ClaimTypes.Name
	   };
   });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
