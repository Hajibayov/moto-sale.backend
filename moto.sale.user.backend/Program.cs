using motosale.user.backend.Extensions;
using motosale.user.backend.Infrastructure;
using motosale.user.backend.Infrastructure.Repository;
using motosale.user.backend.Models;
using motosale.user.backend.Services.Implementation;
using motosale.user.backend.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;
using Npgsql.Internal.TypeHandlers.NetworkHandlers;
using billkill.payment.service.Models;
using billkill.manager.backend.Services.Implementation;
using motosale.user.backend.Extensions;
using moto.sale.user.backend.Services.Implementation;
using moto.sale.user.backend.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(x => x.AddProfile(new MappingEntity()));
builder.Services.ConfigureCors();
builder.Services.ConfigureJWTService();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureDataProtectionTokenProvider();

builder.Services.AddTransient<ISqlService, SqlService>();
builder.Services.AddTransient<ICmdService, CmdService>();
builder.Services.AddTransient<IJwtHandler, JwtHandler>();

builder.Services.AddTransient<ICompanyEmployeeService, CompanyEmployeeService>();
builder.Services.AddTransient<IValidationCommon, ValidationCommon>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IBlogService, BlogService>();
builder.Services.AddTransient<ILookupService, LookupService>();

builder.Services.AddDbContext<MotoSaleDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<USER, USER_ROLE>(options =>
{

})
.AddRoles<USER_ROLE>()
.AddEntityFrameworkStores<MotoSaleDbContext>()
.AddDefaultTokenProviders();

//Logs
builder.Host.ConfigureLogging((hostingContext, logging) =>
{
    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    logging.AddDebug();
    logging.AddNLog();
});

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//app.UseClientRateLimiting();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.MapControllers();
app.Run();
