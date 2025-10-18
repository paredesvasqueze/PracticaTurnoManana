using Data;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Servicios existentes
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoServiceDb>();

// Servicio y repositorio para Cita Médica
builder.Services.AddScoped<ICitaMedicaRepository, CitaMedicaRepository>();
builder.Services.AddScoped<ICitaMedicaServiceDb, CitaMedicaService>();

// Agregar controladores con vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

