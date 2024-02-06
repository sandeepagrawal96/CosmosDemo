
using CosmosDemo.Core;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICosmosDbService>(cosmosDB.InitializeCosmosClientInstanceAsync(builder.Configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );
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

public static class cosmosDB
{

    public static async Task<CosmosDbService> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
    {
        var databaseName = configurationSection["DatabaseName"];
        var containerName = configurationSection["ContainerName"];
        var account = configurationSection["Account"];
        var key = configurationSection["Key"];
        var client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
        var database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
        //await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");
        var cosmosDbService = new CosmosDbService(client, databaseName, containerName);
        return cosmosDbService;
    }
}
