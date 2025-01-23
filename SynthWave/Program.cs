using Serilog;
using SynthWave.Configurations;
using SynthWave.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<SynthWaveDbContext>();

// 日志
builder.Host.UseSerilog((context, _, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();