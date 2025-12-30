using EmployeeAPI.Data;
using EmployeeAPI.Implementation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
//Add dbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSsql")));

//inyección capa de datos
builder.Services.AddScoped<IEmployeeData, EmployeeData>().AddScoped<IGroupData, GroupData>().AddScoped<IDepartmentData, DepartmentData>();

//inyección capa de reglas de negocio
builder.Services.AddScoped<IEmployeeImpl, EmployeeImpl>().AddScoped<IGroupImpl, GroupImpl>().AddScoped<IDepartmentImpl, DepartmentImpl>();

//Add Automapper 
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MiPoliticaCORS",
        builder => builder.WithOrigins("http://localhost:3400")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


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

app.UseCors("MiPoliticaCORS");

app.Run();
