// See https://aka.ms/new-console-template for more information
using SLG.Aplicacion;
using SLG.Repositorios;

SecuenciaExpedienteTXT secuenciaExpediente = new SecuenciaExpedienteTXT();
SecuenciaTramiteTXT secuenciaTramite = new SecuenciaTramiteTXT();



var validadorExp = new ValidadorExpediente();
var validadorTram = new ValidadorTramite();

var especificacionCambioDeEstado =  new EspecificacionCambioDeEstado();
var servicioAutorizacion = new ServicioAutorizacionProvisorio();
var servicioActualizacion = new ServicioActualizacionDeEstado(especificacionCambioDeEstado, repoExp);

using var context = new SLGContext();

context.Add(new Expediente("pene"));
context.Add(new Tramite(1,"pijita"));
context.SaveChanges(); 