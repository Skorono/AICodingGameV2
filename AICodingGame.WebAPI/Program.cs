using AICodingGame.Core.Services;
using AICodingGame.DAL.Context;
using AICodingGame.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<GameContext>(options => 
    options.UseNpgsql(builder.Configuration["DefaultConnection"]));

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

builder.Services.AddScoped<IRobotRepository, RobotRepository>();
builder.Services.AddScoped<RobotService>();
builder.Services.AddScoped<IBattleRepository, BattleRepository>();
builder.Services.AddScoped<BattleService>();
//builder.Services.AddScoped<StatisticService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(act => act.RoutePrefix = "");
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
