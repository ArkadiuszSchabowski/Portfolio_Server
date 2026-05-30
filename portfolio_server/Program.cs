using portfolio_server.Infrastructure;
using portfolio_server.Interfaces;
using portfolio_server.Models;
using portfolio_server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://arkadiusz-schabowski.netlify.app")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISenderFactory, SenderFactory>();

builder.Services.AddSingleton<EmailAuthentication>(sp =>
{
    var emailAuthentication = new EmailAuthentication();
    builder.Configuration.GetSection("EmailAuthentication").Bind(emailAuthentication);
    return emailAuthentication;
});

builder.Services.AddSingleton<IEmailAuthentication>(sp =>
    sp.GetRequiredService<EmailAuthentication>());

var app = builder.Build();

app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();