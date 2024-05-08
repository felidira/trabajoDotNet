namespace SLG.Aplicacion;

class CasoDeUsoExpedienteConsultarPorId(IRepositorioExpediente repo)
{
    public Expediente Ejecutar(int idUsuario, Expediente expediente)
    {
        ServicioAutorizacionProvicional autorizacion = new ServicioAutorizacionProvicional();
        if (autorizacion.PoseeElPermiso(idUsuario))
        {
            return = repo.ConsultaPorId(expediente.id);
        } else throw new AutorizacionException;
        return null;
    }
}