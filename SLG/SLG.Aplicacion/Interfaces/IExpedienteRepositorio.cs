namespace SLG.Aplicacion;

public interface IExpedienteRepositorio
{
    void AgregarExpediente(Expediente expediente);
    void EliminarExpediente(int expedienteID);
    void ModificarExpediente(Expediente expediente);
    Expediente? ConsultaPorId(int expedienteID);
    void ConsultaTodos();
}