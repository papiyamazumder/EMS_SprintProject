using System.Text;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using EmsData.DataContext;
using EmsData.Repository;
using EmsBusiness.Services;
using Microsoft.AspNetCore.Mvc;
using NLog.Extensions.Logging;

var logger = NLogBuilder.ConfigureNLog("nLog.config").GetCurrentClassLogger();

var builder = WebApplication.CreateBuilder(args);

try
{
    builder.Services.AddControllers();

    // Configuring API versioning
    builder.Services.AddApiVersioning(x =>
    {
        x.DefaultApiVersion = new ApiVersion(1, 0);
        x.AssumeDefaultVersionWhenUnspecified = true;
        x.ReportApiVersions = true;
    });

    // Configuring Entity Framework Core DbContext
    string constr = builder.Configuration.GetConnectionString("sqlcon");
    builder.Services.AddDbContext<EmsDbContext>(options => options.UseSqlServer(constr));

    // Registering services
    builder.Services.AddScoped<DepartmentService, DepartmentService>();
    builder.Services.AddScoped<EmployeeService, EmployeeService>();
    builder.Services.AddScoped<User_MasterService, User_MasterService>();
    builder.Services.AddScoped<Grade_MasterService, Grade_MasterService>();
    builder.Services.AddScoped<LoginService, LoginService>();

    // Registering repositories
    builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
    builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
    builder.Services.AddScoped<IUser_MasterRepo, User_MasterRepo>();
    builder.Services.AddScoped<IGrade_MasterRepo, Grade_MasterRepo>();

    // Adding Swagger/OpenAPI support
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCors();

    // Configuring logging
    builder.Services.AddLogging(log => { log.ClearProviders(); log.AddNLog(); });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Configuring CORS policy
    app.UseCors(x => x.AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(origin => true)
                        .AllowCredentials());

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program");
}
finally
{
    NLog.LogManager.Shutdown();
}
