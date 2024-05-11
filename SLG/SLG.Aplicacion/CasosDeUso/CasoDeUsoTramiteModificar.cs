namespace SLG.Aplicacion;

public class CasoDeUsoTramiteModificar(ITramiteRepositorio repoT,ServicioAutorizacionProvisorio autorizacion){

    public void Ejecutar(int idUsuario,Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)) {
            tramite.ultModificacion=DateTime.Now;
            tramite.ultModificacionID=idUsuario;
            repoT.ModificarTramite(tramite);
        } else throw new AutorizacionException();
    }
}