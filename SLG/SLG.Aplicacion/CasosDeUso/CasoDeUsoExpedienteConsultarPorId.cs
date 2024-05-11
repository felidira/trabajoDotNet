namespace SLG.Aplicacion;

class CasoDeUsoExpedienteConsultarPorId(ITramiteRepositorio repoT,IExpedienteRepositorio repoE)
{
    public Expediente Ejecutar(int expedienteId)
    {
        Expediente expediente = repoE.ConsultaPorId(expedienteId); 
        expediente.listaTramites=repoT.ConsultaPorIdExpediente(expedienteId);
        return expediente;
    }
}