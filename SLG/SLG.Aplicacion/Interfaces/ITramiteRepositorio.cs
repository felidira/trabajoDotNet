namespace SLG.Aplicacion;

public interface ITramiteRepositorio{
    void AgregarTramite(Tramite tramite);
    void EliminarTramite(Tramite tramite);
    void ModificarTramite(Tramite tramite);
    List<Tramite> ConsultaTodosTramite();

    List<Tramite> ConsultaPorIdExpediente(int idExpediente);
    List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta);
}