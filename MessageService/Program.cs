using MessageService;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServiceBusClient(azureServiceBusConnectionString)
    .WithName("AzureServiceBus")
    .ConfigureOptions(options =>
    {
        options.RetryOptions.Delay = TimeSpan.FromMilliseconds(50);
        options.RetryOptions.MaxDelay = TimeSpan.FromSeconds(2);
        options.RetryOptions.MaxRetries = 3;
    });
builder.Services.AddScoped<AzureServiceBusTopicSender>();
var app = builder.Build();

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
