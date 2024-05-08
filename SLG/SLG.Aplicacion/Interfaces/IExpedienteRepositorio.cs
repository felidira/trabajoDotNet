namespace SLG.Aplicacion;

public interface IExpedienteRepositorio
{
    void AgregarExpediente(Expediente expediente);
    void EliminarExpediente();
    void ModificarExpediente(Expediente expediente);
    Expediente ConsultaPorId(int id);
    void ConsultaTodos();
}