using BookStore.Data;
using BookStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddHealthChecks();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddNpgsql<BookStoreContext>(builder.Configuration.GetConnectionString("BookStoreDatabase"));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (builder.Configuration.GetValue<bool>("UseSwagger"))
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore  V1");
        c.RoutePrefix = string.Empty; 
    });
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");


app.Run();
