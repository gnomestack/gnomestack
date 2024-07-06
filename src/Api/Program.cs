using Gs.Data.Models;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    o.AddPolicy("SelfHost",
        b => b.WithOrigins("http://localhost:5000", "http://localhost:5173").AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddGsDbContext(o =>
{
    o.UseSqlite("Data Source=app.db");
    o.UseSnakeCaseNamingConvention();
});



var app = builder.Build();
app.UseCors("SelfHost");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGsIdentityApi();
app.UseHttpsRedirection();
app.MapGroup("/api/v1")
    .MapGet("setup", async (GsDbContext db) =>
    {
         await db.Database.EnsureCreatedAsync();
         return TypedResults.Ok(true);
    })
.WithOpenApi();

await app.RunAsync();