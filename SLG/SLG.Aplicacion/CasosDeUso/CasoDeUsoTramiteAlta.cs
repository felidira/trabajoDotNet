namespace SLG.Aplicacion;

public class CasoDeUsoTramiteAlta(IContextDB context,ValidadorID VID,ServicioAutorizacionProvisorio autorizacion, ValidadorTramite validador, ServicioActualizacionDeEstado actualizacion)
{
  public void Ejecutar(int idUsuario, Tramite tramite)
  {
    if (VID.ValidarId(idUsuario)){
      if (autorizacion.PoseeElPermiso(idUsuario))
      {
        if (validador.ValidarTramite(tramite)){
          tramite.fechaCreacion=DateTime.Now;
          tramite.ultModificacion=tramite.fechaCreacion;
          tramite.ultModificacionID=idUsuario;
          context.AgregarTramite(tramite,true);
          Expediente e = context.ConsultaPorId(tramite.ExpedienteId);
          e.listaTramites=context.ConsultaPorIdExpediente(e.id);
          actualizacion.actualizar(e);
        } else throw new ValidacionException();
      } else throw new AutorizacionException();      
    } else throw new Exception("id de usuario no valido");
  }
}
