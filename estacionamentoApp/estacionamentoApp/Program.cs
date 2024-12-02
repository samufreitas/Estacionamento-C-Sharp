using estacionamentoApp.Data;
using estacionamentoApp.Services.ClienteService;
using estacionamentoApp.Services.EmpresaService;
using estacionamentoApp.Services.EnderecoService;
using estacionamentoApp.Services.Estacionamento;
using estacionamentoApp.Services.FilialService;
using estacionamentoApp.Services.VeiculoEstacionamentoService;
using estacionamentoApp.Services.VeiculoService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 4, 0))
    );
});

//Comunicação da Interface com a Service 
builder.Services.AddScoped<IClienteInterface, ClienteSerivce>();
builder.Services.AddScoped<IVeiculoInterface, VeiculoService>();
builder.Services.AddScoped<IEmpresaInterface, EmpresaService>();
builder.Services.AddScoped<IFilialInterface, FilialService>();
builder.Services.AddScoped<IEnderecoInterface, EnderecoService>();
builder.Services.AddScoped<IEstacionamentoInterface, EstacionamentoService>();
builder.Services.AddScoped<IVeiculoEstacionamentoInterface, VeiculoEstacionamentoService>();



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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
