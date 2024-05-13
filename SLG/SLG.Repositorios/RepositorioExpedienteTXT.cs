using System.Data;
using SLG.Aplicacion;
namespace SLG.Repositorios;

public class RepositorioExpedienteTXT(SecuenciaExpedienteTXT secuenciaIDS) : IExpedienteRepositorio 
{
    readonly String nombreArch= "archivo.txt";
    public void AgregarExpediente(Expediente expediente, bool secuencia) //true = lee secuencia (nuevos expedientes) false = lee id que ya tiene el expediente
    {
        using StreamWriter sw = new StreamWriter(nombreArch,true);
        if (secuencia){
            sw.WriteLine(secuenciaIDS.LeerID());
        } else
        {
            sw.WriteLine(expediente.id);
        }
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
            E.estado=(EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "");
            resultado.Add(E);
        }
        return resultado;
    }

    public Expediente ConsultaPorId(int idaBuscar)
    {
        List<Expediente> lista=ConsultaTodos();
        Expediente expediente= new Expediente();
        int pos = 0;
        while (pos < (lista.Count()-1) && lista[pos].id != idaBuscar)
        {
            pos++;
        }
        if (lista[pos].id == idaBuscar)
        {
            expediente = lista[pos];
        }
        return expediente;
    }
    
    public void EliminarExpediente(Expediente expediente)
    {
        var lista = ConsultaTodos();
        List<Expediente> listanueva = new List<Expediente>();
        foreach (Expediente e in lista){
            if (e.id != expediente.id)
            {
                listanueva.Add(e);
            }
        }
        File.Delete(nombreArch);
        foreach (Expediente e in listanueva){
            AgregarExpediente(e,false);
        }
    }

    public void ModificarExpediente(Expediente expediente)
    {
        var lista = ConsultaTodos();
        int pos=0;
        while (pos < lista.Count-1 && lista[pos].id != expediente.id) {
            pos++;
        }
        if (lista[pos].id == expediente.id){
            lista[pos]=expediente;
        }
        File.Delete(nombreArch);
        foreach (Expediente e in lista){
            AgregarExpediente(e,false);
        }
    }
}
