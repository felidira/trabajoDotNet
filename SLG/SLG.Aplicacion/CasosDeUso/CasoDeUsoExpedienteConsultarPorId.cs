namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteConsultarPorId(IExpedienteRepositorio repoE)
{
    public Expediente Ejecutar(int expedienteId)
    {
        Expediente expediente = repoE.ConsultaPorId(expedienteId); 
        return expediente;
    }
}