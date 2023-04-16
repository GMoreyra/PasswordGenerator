using Microsoft.OpenApi.Models;
using PasswordGenerator.SwaggerFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Password Generator API", Version = "v1" });
    options.OperationFilter<PasswordGeneratorOperationFilter>();
});
builder.Services.AddScoped<IPasswordGeneratorService, PasswordGenerator.Services.PasswordGeneratorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Password Generator API v1");
    });
}

app.UseHttpsRedirection();

app.MapGet("/api/passwordgenerator",
    (IPasswordGeneratorService passwordGenerator, int length, bool upperCase, bool numbers, bool symbols) =>
        passwordGenerator.Generate(length, upperCase, numbers, symbols))
    .WithName("GeneratePassword");

app.Run();