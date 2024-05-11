namespace SLG.Aplicacion;

public interface ITramiteRepositorio
{
  public void AgregarTramite(Tramite tramite);
  public void EliminarTramite(Tramite tramite);
  public void ModificarTramite(Tramite tramite);
  public List<Tramite> ConsultaPorIdExpediente(int idExpediente);
  public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta);
}
  
