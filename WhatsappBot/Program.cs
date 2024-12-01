using WhatsappBot.Application.Interfaces;
using WhatsappBot.Application.Services;
using WhatsappBot.Infraestructure.HttpClients;

var builder = WebApplication.CreateBuilder(args);

var whatsAppConfig = builder.Configuration.GetSection("WhatsApp").Get<WhatsAppConfiguration>();
builder.Services.AddSingleton(whatsAppConfig);

builder.Services.AddHttpClient<WhatsAppHttpClient>();

builder.Services.AddScoped<IWhatsappAppService, WhatsappService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WhatsApp API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
