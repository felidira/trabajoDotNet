namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteConsultarPorId(IMetodosDB metodos)
{
    public Expediente Ejecutar(int expedienteId)
    {
        Expediente expediente = metodos.ConsultaPorId(expedienteId); 
        return expediente;
    }
}