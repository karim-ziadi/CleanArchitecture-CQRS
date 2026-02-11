using API.Exceptions;
using Application.Behaviors;
using Application.Common.Interfaces;
using FluentValidation;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(Application.IAssemblyMarker).Assembly);
});
builder.Services.AddValidatorsFromAssembly(typeof(Application.IAssemblyMarker).Assembly);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddScoped<IAppDbContext, AppDbContext>();  
var app = builder.Build();
app.UseExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
