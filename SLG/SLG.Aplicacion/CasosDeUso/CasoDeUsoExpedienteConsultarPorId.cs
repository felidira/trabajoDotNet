namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteConsultarPorId(IContextDB context)
{
    public Expediente Ejecutar(int expedienteId)
    {
        Expediente expediente = context.ConsultaPorId(expedienteId); 
        expediente.listaTramites=context.ConsultaPorIdExpediente(expedienteId);
        return expediente;
    }
}