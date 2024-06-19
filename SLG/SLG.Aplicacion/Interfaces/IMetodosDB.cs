namespace SLG.Aplicacion;

public interface IMetodosDB
{
    void AgregarExpediente(Expediente expediente);
    void EliminarExpediente(Expediente expediente);
    void ModificarExpediente(Expediente expediente);
    Expediente ConsultaPorId(int expedienteId);
    List<Expediente> ConsultaTodos();
    void AgregarTramite(Tramite tramite);
    void EliminarTramite(Tramite tramite);
    void ModificarTramite(Tramite tramite);
    List<Tramite> ConsultaPorIdExpediente(int idExpediente);
    List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta);
    Usuario BuscarUsuario(String correo);
}