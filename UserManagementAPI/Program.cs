using UserManagementAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddSecretsExtension(builder.Configuration); // Env secrets config registration.

// builder.Services.AddOpenApiExtension();

// builder.Host.AddSerilogLogging(); // Logger configuration.

builder.Services.AddControllers();

builder.Services.RegisterValidators();
builder.Services.RegisterServices();

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseMiddlewareExtension(); // Custom middleware registration.

app.MapControllers();

app.Run();