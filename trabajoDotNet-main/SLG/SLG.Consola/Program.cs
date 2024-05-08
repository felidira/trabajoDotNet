// See https://aka.ms/new-console-template for more information
using SLG.Aplicacion;
using SLG.Repositorios;

IExpedienteRepositorio repo = new RepositorioExpedienteTXT();

var agregarExpediente = new CasoDeUsoExpedienteAlta(repo);

agregarExpediente.Ejecutar(new Expediente(1,"lll"));

