using Microsoft.EntityFrameworkCore;
using StudentCrudApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// Configure MySQL Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configure CORS (allows frontend to connect)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // React default port
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// // Configure the HTTP request pipeline
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();

Console.WriteLine("✅ API is running!");
Console.WriteLine("   GET    http://localhost:5001/api/students");
Console.WriteLine("   POST   http://localhost:5001/api/students");
Console.WriteLine("   GET    http://localhost:5001/api/students/1");
Console.WriteLine("   PUT    http://localhost:5001/api/students/1");
Console.WriteLine("   DELETE http://localhost:5001/api/students/1");

app.Run();