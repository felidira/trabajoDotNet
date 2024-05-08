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
            T.fechaCreacion= DateTime.Parse(sr.ReadLine() ?? "");
            T.ultModificacion= DateTime.Parse(sr.ReadLine() ?? "");
            T.ultModificacionID= int.Parse(sr.ReadLine() ?? "-1");
            resultado.Add(T);
        }
        return resultado;
    }

    private Tramite? BuscarUltTramite(int idABuscar)
    {
        List<Tramite> lista = ListarTramites();
        Tramite? devuelvo = null;
        int pos=0;
        while (pos < lista.Count){
            devuelvo = (lista[pos].id == idABuscar) ? lista[pos] : null;
            pos++;
        }
        if (devuelvo == null)
        { 
            Console.WriteLine($"No se encontró el tramite del expediente {idABuscar}");
        }
        return devuelvo;
    }

    public void EliminarTramite(Tramite tramite)
    {
        List<Tramite> lista= ListarTramites();
        lista.Remove(tramite);
        File.Delete(nombreArch);
        foreach (Tramite t in lista)
        {
            AgregarTramite(t);
        }
    }

    public void ModificarTramite(Tramite tramite)
    {
        List<Tramite> lista=ListarTramites();
        int pos = 0;
        while (pos < lista.Count && lista[pos].id != tramite.id)
        {
            if (tramite.id == lista[pos].id) 
            {
                lista[pos]=tramite;
            }
        }
        File.Delete(nombreArch);
        foreach (Tramite t in lista)
        {
            AgregarTramite(t);
        }
    }
}