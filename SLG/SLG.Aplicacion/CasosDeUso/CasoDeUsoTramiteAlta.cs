namespace SLG.Aplicacion;

class CasoDeUsoTramiteAlta(ITramiteRepositorio repo)
{
  public void Ejecutar(int idUsuario, Tramite tramite)
  {
    ServicioAutorizacionProvicional autorizacion = new ServicioAutorizacionProvicional();
    if (autorizacion.PoseeElPermiso(idUsuario))
    {
      repo.AgregarTramite(tramite);
    } else throw new AutorizacionException;
  }
}
