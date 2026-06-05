using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                "http://127.0.0.1:5500",
                "http://localhost:5500"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddSingleton<MongoClient>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    var settings = MongoClientSettings.FromConnectionString(
        config["MongoDb:ConnectionString"]);

    return new MongoClient(settings);
});

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<MongoClient>();
    var config = sp.GetRequiredService<IConfiguration>();

    return client.GetDatabase(config["MongoDb:DatabaseName"]);
});

builder.Services.AddScoped<CreatePassword>();
builder.Services.AddScoped<CreateFinancial>();
builder.Services.AddScoped<CreateAddress>();
builder.Services.AddScoped<CreateDataBasic>();
builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));

builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();