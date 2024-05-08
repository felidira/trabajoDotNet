namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo)
{
    public void Ejecutar(Expediente expediente)
    {
        repo.AgregarExpediente(expediente);
    }
}