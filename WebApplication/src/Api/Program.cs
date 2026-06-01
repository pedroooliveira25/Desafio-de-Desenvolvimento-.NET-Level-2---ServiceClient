
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<CreatePassword>();
builder.Services.AddScoped<CreateFinancial>();
builder.Services.AddScoped<CreateAddress>();
builder.Services.AddScoped<CreateDataBasic>();

builder.Services.AddAuthorization();



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


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var config = builder.Configuration;

        var key = config.GetValue<string>("Jwt:Key");
        var issuer = config.GetValue<string>("Jwt:Issuer");
        var audience = config.GetValue<string>("Jwt:Audience");

        if (string.IsNullOrEmpty(key))
            throw new Exception("Jwt:Key não encontrado no appsettings");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = issuer,
            ValidAudience = audience,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key))
        };
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();