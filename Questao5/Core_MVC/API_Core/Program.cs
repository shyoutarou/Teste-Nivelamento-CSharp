using MediatR;
using Microsoft.AspNetCore.Localization;
using Questao5_Data.Infrastructure.Database.CommandStore.Requests;
using Questao5_Data.Infrastructure.Database.QueryStore.Requests;
using Questao5_Data.Infrastructure.Sqlite;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IContaCorrenteQuery, ContaCorrenteQuery>();
builder.Services.AddTransient<IContaCorrenteCommand, ContaCorrenteCommand>();
builder.Services.AddTransient<IMovimentacaoQuery, MovimentacaoQuery>();
builder.Services.AddTransient<IMovimentacaoCommand, MovimentacaoCommand>();
builder.Services.AddTransient<IIdempotenciaQuery, IdempotenciaQuery>();
builder.Services.AddTransient<IIdempotenciaCommand, IdempotenciaCommand>();

//utilização do MediatR pode ajudar a implementar o requisito de resiliência a falha
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddHostedService<StatusCheckerService>();

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

var supportedCultures = new[] { new CultureInfo("pt-BR") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

//app.UseWebSockets(); // Configurar o middleware para WebSockets

//app.UseRouting();

// sqlite: CHAMADA PARA CARREGAMENTO DOS DADOS
app.Services.GetService<IDatabaseBootstrap>().Setup();

app.Run();
