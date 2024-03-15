using AutoglassChallenge.Infra;
using AutoglassChallenge.Infra.IoC;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database

builder.Services.AddDbContext<AutoglassChallengeContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("AutoglassChallengeDefaultConnection")), ServiceLifetime.Transient);

#endregion Database

#region Injections

Injector.InjectIoCServices(builder.Services);
builder.Services.AddSingleton(x => builder.Configuration);
builder.Services.AddSingleton(AutoMapperProfileConfig.CreateMapperConfiguration().CreateMapper());

#endregion Injections

#region AutoMapperConfiguration

var configuration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AutoMapperProfileConfig>();
});

#endregion

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
