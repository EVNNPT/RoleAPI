using Microsoft.EntityFrameworkCore;
using RoleDatas.DBModels;
using RoleServices;

var builder = WebApplication.CreateBuilder(args);
string _myPolicyCors = "_myPolicyCors";
// add dbcontext
var connectionString = builder.Configuration.GetValue<String>("DatabaseSettings:ConnectionString");
builder.Services.AddDbContext<RoleContext>(x => x.UseOracle(connectionString));
builder.Services.AddScoped<IDuongDayServices, DuongDayServices>();
builder.Services.AddScoped<IRoLeServices, RoLeServices>();
builder.Services.AddScoped<IMayBienApServices, MayBienApServices>();
builder.Services.AddScoped<IThanhCaiServices, ThanhCaiServices>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: _myPolicyCors,
                                  builder =>
                                  {
                                      builder
                                        //.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials()
                                        .SetIsOriginAllowed(x => true);
                                  });
            });
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
app.UseCors(_myPolicyCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
