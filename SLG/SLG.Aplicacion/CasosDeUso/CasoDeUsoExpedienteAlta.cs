namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteAlta(IMetodosDB metodos,ValidadorID VID, ServicioAutorizacion autorizacion, ValidadorExpediente validador)
{
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (VID.ValidarId(idUsuario))
        {
            if (autorizacion.PoseeElPermiso(metodos.BuscarUsuario(idUsuario).permisos, Permiso.ExpedienteAlta))
            {
                if (validador.ValidarExp(expediente))
                {
                    expediente.fechaCreacion=DateTime.Now;
                    expediente.ultModificacion=expediente.fechaCreacion;
                    expediente.ultModificacionID=idUsuario;
                    metodos.AgregarExpediente(expediente);
                } else throw new ValidacionException();
            } else throw new AutorizacionException();
        } else throw new Exception("id de usuario no valido");
    }
}