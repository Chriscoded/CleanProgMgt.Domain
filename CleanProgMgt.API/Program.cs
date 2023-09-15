using CleanProgMgt.Application.Services.Notifications;
using CleanProgMgt.Application.Services.Projects;
using CleanProgMgt.Application.Services.Task;
using CleanProgMgt.Application.Services.Users;
using CleanProgMgt.Domain;
using CleanProjMgt.Infrastructure;
//using CleanProjMgt.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using Hangfire;
using Hangfire.SqlServer;
using CleanProgMgt.Application.Services.BackgroundService;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddNLog();

//Register configuration]
ConfigurationManager configuration = builder.Configuration;

// builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
    {
        ReferenceHandler = ReferenceHandler.Preserve,
    }));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

//Add Database service
builder.Services.AddDbContext<TasksDbContext>(
        opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
        b => b.MigrationsAssembly("CleanProgMgt.API")
        //opt => opt.EnableSensitiveDataLogging() // Enable sensitive data logging
));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));
builder.Services.AddHangfireServer();
//builder.Services.AddHangfireServer(options =>
//    options.SchedulePollingInterval = TimeSpan.FromSeconds(5)
//   );
// Add services to the container.
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<INotificationsService, NotificationsService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

builder.Services.AddScoped<IBackgroundServices, CleanProgMgt.Application.Services.BackgroundService.BackgroundService>();

//builder.Services.AddHostedService<NotificationBackgroundService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<IBackgroundServices>("due-time", service => service.tasksDueSoon(),
            Cron.Minutely);

app.MapControllers();

app.Run();
