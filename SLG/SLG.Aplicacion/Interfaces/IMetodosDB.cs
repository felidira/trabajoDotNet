namespace SLG.Aplicacion;

public interface IMetodosDB
{
    void AgregarExpediente(Expediente expediente);
    void EliminarExpediente(Expediente expediente);
    void ModificarExpediente(Expediente expediente);
    Expediente ConsultaPorId(int expedienteId);
    List<Expediente> ConsultaTodos();
    void AgregarTramite(Tramite tramite);
    void EliminarTramite(Tramite tramite);
    void ModificarTramite(Tramite tramite);
    List<Tramite> ConsultaTodosTramite();

    List<Tramite> ConsultaPorIdExpediente(int idExpediente);
    List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta);
    Usuario BuscarUsuario(int id);
    void AgregarPermiso(int idUsuario, Permiso Aagregar);
    void EliminarPermiso(int idUsuario, Permiso Aeliminar);
    bool ValidarCorreo(Usuario usuario);
    void AgregarUsuario(Usuario usuario);
    bool ComprobarUsuario(Usuario usuario);
    void ModificarUsuario(Usuario usuario);
    Usuario BuscarUsuario(Usuario usuario);
    List<Usuario> ListarUsuarios();
}
