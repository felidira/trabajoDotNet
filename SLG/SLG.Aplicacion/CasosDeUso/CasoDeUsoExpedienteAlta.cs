namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteAlta(IContextDB context,ValidadorID VID, ServicioAutorizacionProvisorio autorizacion, ValidadorExpediente validador)
{
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (VID.ValidarId(idUsuario))
        {
            if (autorizacion.PoseeElPermiso(idUsuario))
            {
                if (validador.ValidarExp(expediente))
                {
                    expediente.fechaCreacion=DateTime.Now;
                    expediente.ultModificacion=expediente.fechaCreacion;
                    expediente.ultModificacionID=idUsuario;
                    context.AgregarExpediente(expediente,true);
                } else throw new ValidacionException();
            } else throw new AutorizacionException();
        } else throw new Exception("id de usuario no valido");
    }
}