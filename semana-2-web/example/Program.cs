using example.application;
using example.domain;
using example.domain.interfaces;
using example.infra;
using Microsoft.AspNetCore.Mvc;
using static example.application.CreateBook;
using static example.application.GetBook;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

List<Book> books = [];
IAddBookRepository addRepository = new AddBookRepository(books);
IGetBookRepository getRepository = new GetBookRepository(books);
ICreateBookHandler addHandler = new CreateBook.Handler(addRepository);
IGetBookHandler getHandler = new GetBook.Handler(getRepository);

app.MapPost("/books", ([FromBody] CreateBookRequest request) => {
    return addHandler.Handle(request);
})
.WithOpenApi();

app.MapGet("/books/{id}", (Guid id) =>
{
    var bookRequest = new GetBookRequest(id);
    return getHandler.Handle(bookRequest);
})
.WithOpenApi();

app.Run();