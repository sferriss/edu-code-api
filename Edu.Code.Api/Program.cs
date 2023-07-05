using System.Text.Json.Serialization;
using Edu.Code.Api.ExceptionHandlers;
using Edu.Code.Api.ExceptionHandlers.Middlewares;
using Edu.Code.Api.Extensions;
using Edu.Code.Application.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureServices();
builder.Services.AddExceptionHandlers()
    .AddHandler<BusinessValidationException, BusinessValidationExceptionHandler>()
    .AddHandler<NotFoundException, NotFoundExceptionHandler>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
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

app.MigrationInitialisation();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();