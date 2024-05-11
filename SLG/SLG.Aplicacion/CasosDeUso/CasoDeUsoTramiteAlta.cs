namespace SLG.Aplicacion;

class CasoDeUsoTramiteAlta(ITramiteRepositorio repoT, ServicioAutorizacionProvisorio autorizacion,IExpedienteRepositorio repoE,ServicioActualizacionDeEstado actualizacion)
{
  public void Ejecutar(int idUsuario, Tramite tramite)
  {
    if (autorizacion.PoseeElPermiso(idUsuario))
    {
      tramite.fechaCreacion=DateTime.Now;
      tramite.ultModificacion=tramite.fechaCreacion;
      tramite.ultModificacionID=idUsuario;
      repoT.AgregarTramite(tramite);
      Expediente e = repoE.ConsultaPorId(tramite.ExpedienteId);
      actualizacion.actualizar(e);
    } else throw new AutorizacionException();
  }
}
