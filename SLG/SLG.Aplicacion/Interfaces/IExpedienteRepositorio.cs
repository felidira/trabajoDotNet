namespace SLG.Aplicacion;

public interface IExpedienteRepositorio
{
    void AgregarExpediente(Expediente expediente);
    void EliminarExpediente(Expediente expediente);
    void ModificarExpediente(Expediente expediente);
    Expediente ConsultaPorId(int expedienteId);
    List<Expediente> ConsultaTodos();
}