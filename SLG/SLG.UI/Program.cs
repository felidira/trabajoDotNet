using SLG.Repositorios;
using SLG.Aplicacion;
using SLG.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IServicioSesion,ServicioSesion>();

builder.Services.AddScoped<SLGContext>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ITramiteRepositorio, TramiteRepositorio>();
builder.Services.AddScoped<IExpedienteRepositorio, ExpedienteRepositorio>();
builder.Services.AddTransient<EspecificacionCambioDeEstado>();
builder.Services.AddTransient<ServicioActualizacionDeEstado>();
builder.Services.AddTransient<ValidadorID>();
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<ServicioAutorizacion>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoUsuarioListarPermisos>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultarPorId>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultarTodos>();
builder.Services.AddTransient<ValidadorExpediente>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificar>();
builder.Services.AddTransient<CasoDeUsoTramiteListar>();
builder.Services.AddTransient<ValidadorTramite>();
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteModificar>();
builder.Services.AddTransient<ValidadorUsuario>();
builder.Services.AddTransient<CasoDeUsoUsuarioListar>();
builder.Services.AddTransient<CasoDeUsoUsuarioBuscar>();
builder.Services.AddTransient<CasoDeUsoUsuarioAgregarPermiso>();
builder.Services.AddTransient<CasoDeUsoUsuarioAgregarUsuario>();
builder.Services.AddTransient<CasoDeUsoUsuarioEliminarPermiso>();
builder.Services.AddTransient<CasoDeUsoUsuarioIniciarSesion>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificar>();

SLGsqlite.Inicializar();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();





