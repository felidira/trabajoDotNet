namespace SLG.Repositorios;
using SLG.Aplicacion;

public class RepositorioTramiteTXT : ITramiteRepositorio
{
    readonly String nombreArch="Tramites.txt";

    public void AgregarTramite(Tramite tramite)
    {
        using StreamWriter sw = new StreamWriter(nombreArch,true);
        sw.WriteLine(tramite.id);
        sw.WriteLine(tramite.ExpedienteId);
        sw.WriteLine(tramite.tipoTramite);
        sw.WriteLine(tramite.contenido);
        sw.WriteLine(tramite.fechaCreacion);
        sw.WriteLine(tramite.ultModificacion);
        sw.WriteLine(tramite.ultModificacionID);
    }
    public void ConsultaPorEtiqueta()
    {
        throw new NotImplementedException();
    }

    public void EliminarTramite(int idElim)
    {
        throw new NotImplementedException();
    }

    public void ModificarTramite(Tramite tramite)
    {
        throw new NotImplementedException();
    }
}