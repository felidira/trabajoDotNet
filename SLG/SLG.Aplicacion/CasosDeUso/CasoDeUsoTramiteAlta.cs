namespace SLG.Aplicacion;

class CasoDeUsoTramiteAlta(ITramiteRepositorio repoT, ServicioAutorizacionProvisorio autorizacion,ValidadorTramite validador,IExpedienteRepositorio repoE,ServicioActualizacionDeEstado actualizacion)
{
  public void Ejecutar(int idUsuario, Tramite tramite)
  {
    if (autorizacion.ValidarId(idUsuario)){
      if (autorizacion.PoseeElPermiso(idUsuario))
      {
        if (validador.ValidarTramite(tramite)){
          tramite.fechaCreacion=DateTime.Now;
          tramite.ultModificacion=tramite.fechaCreacion;
          tramite.ultModificacionID=idUsuario;
          repoT.AgregarTramite(tramite);
          Expediente e = repoE.ConsultaPorId(tramite.ExpedienteId);
          actualizacion.actualizar(e);
        } else throw new ValidacionException();
      } else throw new AutorizacionException();      
    } else throw new Exception("id de usuario no valido");
  }
}
