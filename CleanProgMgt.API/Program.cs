using CleanProgMgt.Application.Services.Notifications;
using CleanProgMgt.Application.Services.Projects;
using CleanProgMgt.Application.Services.Task;
using CleanProgMgt.Application.Services.Users;
using CleanProgMgt.Domain;
using CleanProjMgt.Infrastructure;
using CleanProjMgt.Infrastructure.Services;
//using CleanProjMgt.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddNLog();

//Register configuration]
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

//Add Database service
builder.Services.AddDbContext<TasksDbContext>(
        opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
        b => b.MigrationsAssembly("CleanProgMgt.API")));

// Add services to the container.
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<INotificationsService, NotificationsService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

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

app.MapControllers();

app.Run();
