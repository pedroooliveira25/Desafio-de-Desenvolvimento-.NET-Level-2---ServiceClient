
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    Console.WriteLine(config["MongoDb:ConnectionString"]);
    Console.WriteLine(config["MongoDb:DatabaseName"]);

    var client = new MongoClient(
        config["MongoDb:ConnectionString"]);

    return client.GetDatabase(
        config["MongoDb:DatabaseName"]);
});


builder.Services.AddScoped<CreatePassword>();
builder.Services.AddScoped<CreateFinancial>();
builder.Services.AddScoped<CreateAddress>();
builder.Services.AddScoped<CreateDataBasic>();
builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();