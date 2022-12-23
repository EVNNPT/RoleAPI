using Microsoft.EntityFrameworkCore;
using RoleDatas.DBModels;

var builder = WebApplication.CreateBuilder(args);

// add dbcontext
var connectionString = builder.Configuration.GetValue<String>("DatabaseSettings:ConnectionString");
builder.Services.AddDbContext<RoleContext> (x => x.UseOracle(connectionString));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
