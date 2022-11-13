using WowBoatApi.DAL;
using WowBoatApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IBoatRepository), typeof(BoatRepository));
builder.Services.AddScoped<WowBoatDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("aeda-46-33-200-144.eu.ngrok.io").AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();