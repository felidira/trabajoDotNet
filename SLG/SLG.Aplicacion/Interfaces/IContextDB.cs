namespace SLG.Aplicacion;

public interface IContextDB
{
    void AgregarExpediente(Expediente expediente,bool secuencia);
    void EliminarExpediente(Expediente expediente);
    void ModificarExpediente(Expediente expediente);
    Expediente ConsultaPorId(int expedienteId);
    List<Expediente> ConsultaTodos();
    void AgregarTramite(Tramite tramite,bool secuencia);
    void EliminarTramite(Tramite tramite);
    void ModificarTramite(Tramite tramite);
    List<Tramite> ConsultaPorIdExpediente(int idExpediente);
    List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta);
}
