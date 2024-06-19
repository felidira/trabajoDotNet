namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteConsultarTodos(IMetodosDB metodos)
{
    public List<Expediente> Ejecutar()
    {
        return metodos.ConsultaTodos();
    }
}