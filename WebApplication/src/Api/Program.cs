using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<CreatePassword>();
builder.Services.AddScoped<CreateFinancial>();
builder.Services.AddScoped<CreateAddress>();
builder.Services.AddScoped<CreateDataBasic>();

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    var client = new MongoClient(
        config["MongoDb:ConnectionString"]);

    return client.GetDatabase(
        config["MongoDb:DatabaseName"]);
});

builder.Services.AddScoped(
    typeof(ICrudRepository<>),
    typeof(CrudRepository<>)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();