namespace SLG.Aplicacion;

class CasoDeUsoTramiteAlta(ITramiteRepositorio repo)
{
  public void Ejecutar(Tramite tramite)
  {
    repo.AgregarTramite(tramite);
  }
}
