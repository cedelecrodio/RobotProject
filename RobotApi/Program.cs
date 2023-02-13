using Application;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Application.Mappers;
using Data.Config;
using Data.Repository;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

//var configuration = new MapperConfiguration(cfg =>
//{
   
//});

//builder.Services.AddSingleton(configuration.CreateMapper());

builder.Services.AddSingleton<IMapperRobot, MapperRobot>();

// Add services to the container.
builder.Services.AddSingleton(typeof(IBaseMovementsRepository<>), typeof(BaseMovementsRepository<>));
builder.Services.AddSingleton(typeof(IRobotRepository), typeof(RobotRepository));

builder.Services.AddSingleton<IRobotService, RobotService>();
builder.Services.AddSingleton(typeof(IApplicationServiceRobot), typeof(ApplicationServiceRobot));
builder.Services.AddSingleton(typeof(IApplicationValidations), typeof(ApplicationValidations));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(name: "RobotOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));


builder.Services.AddDbContext<ContextBase>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Singleton);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("RobotOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
