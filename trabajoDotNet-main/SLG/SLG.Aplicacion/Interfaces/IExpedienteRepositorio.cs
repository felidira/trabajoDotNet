namespace SLG.Aplicacion;

public interface IExpedienteRepositorio
{
    void AgregarExpediente(Expediente expediente);
    void EliminarExpediente();
    void ModificarExpediente();
    void ConsultaPorId();
    void ConsultaTodos();
}