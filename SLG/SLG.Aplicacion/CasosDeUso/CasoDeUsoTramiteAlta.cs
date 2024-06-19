namespace SLG.Aplicacion;

public class CasoDeUsoTramiteAlta(IMetodosDB metodos,ValidadorID VID,ServicioAutorizacion autorizacion, ValidadorTramite validador, ServicioActualizacionDeEstado actualizacion)
{
  public void Ejecutar(int idUsuario, Tramite tramite)
  {
    if (VID.ValidarId(idUsuario)){
      if (autorizacion.PoseeElPermiso(metodos.BuscarUsuario(idUsuario).permisos, Permiso.TramiteAlta))
      {
        if (validador.ValidarTramite(tramite)){
          tramite.fechaCreacion=DateTime.Now;
          tramite.ultModificacion=tramite.fechaCreacion;
          tramite.ultModificacionID=idUsuario;
          metodos.AgregarTramite(tramite);
          Expediente e = metodos.ConsultaPorId(tramite.ExpedienteId);
          actualizacion.actualizar(e);
        } else throw new ValidacionException();
      } else throw new AutorizacionException();      
    } else throw new Exception("id de usuario no valido");
  }
}
