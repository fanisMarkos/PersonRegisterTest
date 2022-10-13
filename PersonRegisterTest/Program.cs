using Microsoft.EntityFrameworkCore;
using PersonRegisterTest.Infrastracture.Entities;
using PersonRegisterTest.Infrastracture.Repository;
using PersonRegisterTest.Infrastracture.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x=>x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
