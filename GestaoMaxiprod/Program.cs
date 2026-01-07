using FluentValidation;
using GestaoMaxiprod.Application;
using GestaoMaxiprod.Application.Categories.Commands.CreateCategoryCommand;
using GestaoMaxiprod.Application.Persons.Commands.CreatePerson;
using GestaoMaxiprod.Application.Transactions.Commands.CreateTransaction;
using GestaoMaxiprod.Infrastructure;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.Converters.Add(
             new JsonStringEnumConverter()
         );
     });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFront",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddApplication();

builder.Services.AddInfrasctrute(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowFront");

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
