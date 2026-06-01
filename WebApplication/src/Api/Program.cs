var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<CreatePassword>();
builder.Services.AddScoped<CreateFinancial>();
builder.Services.AddScoped<CreateAddress>();
builder.Services.AddScoped<CreateDataBasic>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();

