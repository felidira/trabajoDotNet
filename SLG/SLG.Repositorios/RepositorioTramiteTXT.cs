namespace SLG.Repositorios;

using System.Collections;
using System.ComponentModel;
using SLG.Aplicacion;

public class RepositorioTramiteTXT(SecuenciaTramiteTXT secuenciaIDS) : ITramiteRepositorio
{
    readonly String nombreArch="Tramites.txt";

    public void AgregarTramite(Tramite tramite, bool secuencia) //true = lee secuencia (nuevos tramites) false = lee id que ya tiene el tramite
    {
        using StreamWriter sw = new StreamWriter(nombreArch,true);
        if (secuencia){
            sw.WriteLine(secuenciaIDS.LeerID());
        } else{
            sw.WriteLine(tramite.id);
        }
        sw.WriteLine(tramite.ExpedienteId);
        sw.WriteLine(tramite.tipoTramite);
        sw.WriteLine(tramite.contenido);
        sw.WriteLine(tramite.fechaCreacion);
        sw.WriteLine(tramite.ultModificacion);
        sw.WriteLine(tramite.ultModificacionID);
    }

    public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta)
    {
        var lista = ListarTramites();
        foreach (Tramite t in lista){
            if (t.tipoTramite!=etiqueta)
            {
                lista.Remove(t);
            }
        }
        return lista;
    }

    public List<Tramite> ConsultaPorIdExpediente(int idExpediente)
    {
        var lista = ListarTramites();
        List<Tramite> listanueva = new List<Tramite>();
        foreach (Tramite t in lista){
            if (t.ExpedienteId==idExpediente)
            {
                listanueva.Add(t);
            }
        }
        return listanueva;
    }

    private List<Tramite> ListarTramites()
    {
        var resultado = new List<Tramite>();
        using var sr = new StreamReader(nombreArch);
        while (!sr.EndOfStream)
            {
            var T = new Tramite();
            T.id = int.Parse(sr.ReadLine() ?? "-1");
            T.ExpedienteId = int.Parse(sr.ReadLine() ?? "-1");
            T.tipoTramite= (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? "0");
            T.contenido= sr.ReadLine();
            T.fechaCreacion= DateTime.Parse(sr.ReadLine() ?? "");
            T.ultModificacion= DateTime.Parse(sr.ReadLine() ?? "");
            T.ultModificacionID= int.Parse(sr.ReadLine() ?? "-1");
            resultado.Add(T);
        }
        return resultado;
    }

    public void EliminarTramite(Tramite tramite)
    {
        List<Tramite> lista= ListarTramites();
        List<Tramite> listanueva= new List<Tramite>();
        foreach (Tramite t in lista){
            if (t.id != tramite.id){
                listanueva.Add(t);
            }
        }
        File.Delete(nombreArch);
        foreach (Tramite t in listanueva)
        {
            AgregarTramite(t,false);
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
            pos++;
        }
        File.Delete(nombreArch);
        foreach (Tramite t in lista)
        {
            AgregarTramite(t,false);
        }
    }
}