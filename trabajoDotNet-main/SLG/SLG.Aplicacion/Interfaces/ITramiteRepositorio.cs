namespace SLG.Aplicacion;

public interface ITramiteRepositorio
{
  public void AgregarTramite(Tramite tramite);
  public void EliminarTramite(Tramite tramite);
  public void ModificarTramite(Tramite tramite);
  public void ConsultaPorEtiqueta();
}
  
