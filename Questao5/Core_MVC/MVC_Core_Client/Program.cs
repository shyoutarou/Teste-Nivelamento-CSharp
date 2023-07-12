using Questao5_Data.Infrastructure.Database.CommandStore.Requests;
using Questao5_Data.Infrastructure.Database.QueryStore.Requests;
using Questao5_Data.Infrastructure.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IContaCorrenteQuery, ContaCorrenteQuery>();
builder.Services.AddTransient<IContaCorrenteCommand, ContaCorrenteCommand>();
builder.Services.AddTransient<IMovimentacaoQuery, MovimentacaoQuery>();
builder.Services.AddTransient<IMovimentacaoCommand, MovimentacaoCommand>();

//            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ContaCorrente}/{action=Index}/{id?}");

// sqlite: CHAMADA PARA CARREGAMENTO DOS DADOS
app.Services.GetService<IDatabaseBootstrap>().Setup();

app.Run();
