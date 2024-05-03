namespace SLG.Repositorios;

using System.ComponentModel;
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

    public List<Tramite> ListarTramites()
    {
        var resultado = new List<Tramite>();
        using var sr = new StreamReader(nombreArch);
        while (!sr.EndOfStream)
            {
            var T = new Tramite();
            T.id = int.Parse(sr.ReadLine() ?? "-1");
            T.ExpedienteId = int.Parse(sr.ReadLine() ?? "-1");
            T.tipoTramite= (EtiquetaTramite)int.Parse(sr.ReadLine() ?? "0");
            T.contenido= sr.ReadLine();
            //T.fechaCreacion= como leemos el DateTime del archivo de txt?
            //T.ultModificacion=
            T.ultModificacionID= int.Parse(sr.ReadLine() ?? "-1");
            resultado.Add(T);
        }
        return resultado;
    }

    private Tramite BuscarIDExpediente(int idABuscar)
    {
        List<Tramite> l=ListarTramites();
        foreach (Tramite t in l){ 
            if (t.ExpedienteId==idABuscar)
                {
                    return t; //hacer con un while
                }
        }
        
    }

    public void EliminarTramite(Tramite tramite)
    {
        throw new NotImplementedException();
    }

    public void ModificarTramite(Tramite tramite)
    {
        throw new NotImplementedException();
    }
}