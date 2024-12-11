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
builder.Services.AddHttpContextAccessor();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();


builder.Services.AddControllers();



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
   .AddJwtBearer("Teacher", options =>
   {
	   options.TokenValidationParameters = new()
	   {
		   ValidateIssuer = false,
		   ValidateAudience = false,
		   ValidateLifetime = true,
		   ValidateIssuerSigningKey = true,
		   ValidAudience = builder.Configuration["Token:Audience"],
		   ValidIssuer = builder.Configuration["Token:Issuer"],
		   IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
		   LifetimeValidator=(notBefore,expires,securityToken,validationParameters)=>expires!=null?expires>DateTime.UtcNow:false,
		   NameClaimType=ClaimTypes.Name,
		   RoleClaimType=ClaimTypes.Role,
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
app.Use(async (context, next) =>
{
	var username = context?.User?.Identity?.IsAuthenticated == true
		? context?.User?.Identity?.Name
		: "Anonim";
	await next.Invoke();
});


app.MapControllers();

app.Run();
