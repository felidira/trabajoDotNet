namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteConsultarTodos(IContextDB context)
{
    public List<Expediente> Ejecutar()
    {
        return context.ConsultaTodos();
    }
}