// See https://aka.ms/new-console-template for more information
using SLG.Aplicacion;
using SLG.Repositorios;


ITramiteRepositorio repoTram = new RepositorioTramiteTXT();
IExpedienteRepositorio repoExp = new RepositorioExpedienteTXT();

var validadorExp = new ValidadorExpediente();
var validadorTram = new ValidadorTramite();

var especificacionCambioDeEstado =  new EspecificacionCambioDeEstado();
var servicioAutorizacion = new ServicioAutorizacionProvisorio();
var servicioActualizacion = new ServicioActualizacionDeEstado(especificacionCambioDeEstado, repoExp);

var agregarExpediente = new CasoDeUsoExpedienteAlta(repoExp, servicioAutorizacion, validadorExp);
var modificarExpediente = new CasoDeUsoExpedienteModificar(repoExp, servicioAutorizacion);
var eliminarExpepediente = new CasoDeUsoExpedienteBaja(repoExp, repoTram, servicioAutorizacion);
var consultarPorIdExpediente = new CasoDeUsoExpedienteConsultarPorId(repoTram, repoExp);
var consultarPorTodosExpediente = new CasoDeUsoExpedienteConsultarTodos(repoExp); 
var agregarTramite = new CasoDeUsoTramiteAlta(repoTram, repoExp, servicioAutorizacion, validadorTram, servicioActualizacion);
var eliminarTramite = new CasoDeUsoTramiteBaja(repoTram, repoExp, servicioAutorizacion, servicioActualizacion);
var consultarPorEtiquetaTramite = new CasoDeUsoTramiteConsultaPorEtiqueta(repoTram);
var ModificarTramite = new CasoDeUsoTramiteModificar(repoTram, repoExp, servicioAutorizacion, servicioActualizacion);



