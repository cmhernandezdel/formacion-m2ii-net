using Example.EntityFramework.Application.Core;
using Example.EntityFramework.Application.Ingredients;
using Example.EntityFramework.Application.Pizzas;
using Example.EntityFramework.Domain.Ingredients;
using Example.EntityFramework.Domain.Pizzas;
using Example.EntityFramework.Infrastructure.EntityFramework;
using Example.EntityFramework.Infrastructure.Ingredients;
using Example.EntityFramework.Infrastructure.Pizzas;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        opts.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddRouting();
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
{
    //string connectionString = "Server=db;Port=3306;Database=mydb;User=user;Password=password;";
    //opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    opts.UseInMemoryDatabase("Database");
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add repositories
builder.Services.AddScoped<ICreatePizzasRepository, CreatePizzasRepository>();
builder.Services.AddScoped<ICreateIngredientsRepository, CreateIngredientsRepository>();
builder.Services.AddScoped<IGetIngredientsRepository, GetIngredientsRepository>();

// Add units of work
builder.Services.AddScoped<ICreatePizzasUnitOfWork, CreatePizzasUnitOfWork>();
builder.Services.AddScoped<ICreateIngredientsUnitOfWork, CreateIngredientsUnitOfWork>();

// Add use cases
builder.Services.AddScoped<IHandler<GetIngredientUseCase.GetIngredientRequest, GetIngredientUseCase.GetIngredientResponse?>, GetIngredientUseCase.Handler>();
builder.Services.AddScoped<IHandler<CreateIngredientUseCase.CreateIngredientRequest, CreateIngredientUseCase.CreateIngredientResponse>, CreateIngredientUseCase.Handler>();
builder.Services.AddScoped<IHandler<CreatePizzaUseCase.CreatePizzaRequest, CreatePizzaUseCase.CreatePizzaResponse?>, CreatePizzaUseCase.Handler>();

var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();