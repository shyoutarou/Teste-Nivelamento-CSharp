using MVC_Core_Client.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddTransient<IContaCorrenteService, ContaCorrenteService>();
builder.Services.AddTransient<IMovimentacaoService, MovimentacaoService>();
builder.Services.AddTransient<IIdempotenciaService, IdempotenciaService>();
builder.Services.AddTransient<HttpClient>();
builder.Services.AddTransient<ApiConfig>();


//utilização do MediatR pode ajudar a implementar o requisito de resiliência a falha
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//Adiciona a URL PADRÂO
builder.Services.AddSingleton(new ApiConfig { BaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl", "https://localhost:44358/") });


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


app.Run();
