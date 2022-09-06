using MessageService;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var azureServiceBusConnectionString = builder.Configuration.GetConnectionString("AzureServiceBus");
if (azureServiceBusConnectionString == null)
    throw new Exception("Service Bus Connection String cannot be null");
builder.Services.AddAzureClients(clientsBuilder =>
                {
                    clientsBuilder.AddServiceBusClient(azureServiceBusConnectionString)
                        .WithName("AzureServiceBus")
                        .ConfigureOptions(options =>
                        {
                            options.RetryOptions.Delay = TimeSpan.FromMilliseconds(50);
                            options.RetryOptions.MaxDelay = TimeSpan.FromSeconds(2);
                            options.RetryOptions.MaxRetries = 3;
                        });
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
