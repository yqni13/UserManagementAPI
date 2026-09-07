using UserManagementAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterEnvSecrets(builder.Configuration);

builder.Services.AddOpenApiExtension();

builder.Host.AddSerilogLogging(); // Logger configuration.

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

builder.Services.RegisterValidators();
builder.Services.RegisterServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterMiddleware();

app.MapControllers();

app.Run();