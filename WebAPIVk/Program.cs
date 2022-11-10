using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPIVk.Data;
using WebAPIVk.Models;
using WebAPIVk.Repositories;
using WebAPIVk.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddTransient<IPosts<List<string>, int>, GetPosts>();
builder.Services.AddTransient<IPreparationStr<List<string>>, PreparationStr>();
builder.Services.AddTransient<ICalculateLetters<List<SortedDictionary<char, int>>, List<string>>, CalculateLetters>();
builder.Services.AddTransient<IConverterToDb<List<string>, List<SortedDictionary<char, int>>>, ConverterToDb>();
builder.Services.AddScoped<IBaseRepository<LetterFromPost>, LetterFromPostRepository>();
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
