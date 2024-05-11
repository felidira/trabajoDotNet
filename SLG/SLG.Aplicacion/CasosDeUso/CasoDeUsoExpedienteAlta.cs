namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ServicioAutorizacionProvisorio autorizacion, ValidadorExpediente validador)
{
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.ValidarId(idUsuario))
        {
            if (autorizacion.PoseeElPermiso(idUsuario))
            {
                if (validador.ValidarExp(expediente))
                {
                    expediente.fechaCreacion=DateTime.Now;
                    expediente.ultModificacion=expediente.fechaCreacion;
                    expediente.ultModificacionID=idUsuario;
                    repo.AgregarExpediente(expediente);
                } else throw new ValidacionException();
            } else throw new AutorizacionException();
        } else throw new Exception("id de usuario no valido");
    }
}