using System.Data;
using SLG.Aplicacion;
namespace SLG.Repositorios;

public class RepositorioExpedienteTXT(SecuenciaExpedienteTXT secuenciaIDS) : IExpedienteRepositorio 
{
    readonly String nombreArch= "archivo.txt";
    public void AgregarExpediente(Expediente expediente)
    {
        using StreamWriter sw = new StreamWriter(nombreArch,true);
        sw.WriteLine(secuenciaIDS.LeerID());
        sw.WriteLine(expediente.caratula);
        sw.WriteLine(expediente.fechaCreacion);
        sw.WriteLine(expediente.ultModificacion);
        sw.WriteLine(expediente.ultModificacionID);
        sw.WriteLine(expediente.estado);
    }

    public List<Expediente> ConsultaTodos()
    {
        var resultado=new List<Expediente>();
        using var sr = new StreamReader(nombreArch);
        while (!sr.EndOfStream)
        {
            var E = new Expediente();
            E.id= int.Parse(sr.ReadLine() ?? "-1");
            E.caratula= sr.ReadLine() ?? "";
            E.fechaCreacion= DateTime.Parse(sr.ReadLine() ?? "");
            E.ultModificacion= DateTime.Parse(sr.ReadLine() ?? "");
            E.ultModificacionID=int.Parse(sr.ReadLine() ?? "-1");
            E.estado=(EstadoExpediente)int.Parse(sr.ReadLine() ?? "");
            resultado.Add(E);
        }
        return resultado;
    }

    public Expediente ConsultaPorId(int idaBuscar)
    {
        List<Expediente> lista=ConsultaTodos();
        Expediente expediente= new Expediente();
        int pos = 0;
        while (lista[pos].id != idaBuscar)
        {
            pos++;
        }
        expediente = lista[pos];
        return expediente;
    }
    
    public void EliminarExpediente(Expediente expediente)
    {
        var lista = ConsultaTodos();
        lista.Remove(expediente);
        File.Delete(nombreArch);
        foreach (Expediente e in lista){
            AgregarExpediente(e);
        }
    }

    public void ModificarExpediente(Expediente expediente)
    {
        var lista = ConsultaTodos();
        int pos=0;
        while (lista[pos].id != expediente.id) {
            pos++;
        }
        lista[pos]=expediente;
        File.Delete(nombreArch);
        foreach (Expediente e in lista){
            AgregarExpediente(e);
        }
    }
}
