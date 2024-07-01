namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteConsultarTodos(IExpedienteRepositorio repoE)
{
    public List<Expediente> Ejecutar()
    {
        return repoE.ConsultaTodos();
    }
}