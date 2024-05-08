namespace SLG.Aplicacion;

class CasoDeUsoModificarTramite(IExpedienteRepositorio)
{
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        ServicioAutorizacionProvicional autorizacion = new ServicioAutorizacionProvicional();
        if (autorizacion.PoseeElPermiso(idUsuario)){
            repo.ModificarExpediente(expediente);
        } else throw new AutorizacionException;
    }
}