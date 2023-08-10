using Practice;
using Practice.Random;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var randomApi = builder.Configuration.GetValue<string>("RandomApi");
var blackList = builder.Configuration.GetSection("Settings:BlackList").Get<string[]>();
var parallelLimit = builder.Configuration.GetSection("Settings:ParallelLimit").Get<int>();
builder.Services.AddSingleton(new StringProcessorConfig() {RandomApi = randomApi, BlackList = blackList, ParallelLimit = parallelLimit});

builder.Services.AddSingleton<IRandomNumber, RandomNumber>();
builder.Services.AddSingleton<StringProcessor>();

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