namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo)
{
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        ServicioAutorizacionProvicional autorizacion = new ServicioAutorizacionProvicional();
        if (autorizacion.PoseeElPermiso(idUsuario))
        {
            repo.AgregarExpediente(expediente);
        } else throw new AutorizacionException;
    }
}