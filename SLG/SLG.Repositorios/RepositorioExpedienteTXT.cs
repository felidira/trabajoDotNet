using System.Data;
using SLG.Aplicacion;
namespace SLG.Repositorios;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    readonly String nombreArch= "archivo.txt";
    public void AgregarExpediente(Expediente expediente)
    {
        using StreamWriter sw = new StreamWriter(nombreArch,true);
        SecuenciaExpedienteTXT SecuenciaIDS= new SecuenciaExpedienteTXT();
        sw.WriteLine(SecuenciaIDS.LeerID());
        sw.WriteLine(expediente.caratula);
        sw.WriteLine(expediente.fechaCreacion);
        sw.WriteLine(expediente.ultModificacion);
        sw.WriteLine(expediente.ultModificacionID);
        sw.WriteLine(expediente.estado);
    }

    public List<Expediente> ListarExpedientes()
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

    public Expediente? ConsultaPorId(int idabuscar)
    {
        List<Expediente> lista=ListarExpedientes();
        Expediente? expediente= null;
        int pos = 0;
        while (pos<lista.Count && lista[pos].id != idabuscar)
        {
            pos++;
        }
        if (lista[pos].id == idabuscar)
        {
            expediente=lista[pos];
        }
        return expediente;
    }

    public void ConsultaTodos()
    {
        throw new NotImplementedException();
    }

    public void EliminarExpediente(int expedienteID)
    {
        throw new NotImplementedException();
    }

    public void CambiarEstadoExpediente(int ExpedienteId, EstadoExpediente nuevoEstado)
    {
        Expediente? exp=ConsultaPorId(ExpedienteId);
        if(exp != null){
            exp.estado=nuevoEstado;
            ModificarExpediente(exp);
        }
    }

    public void ModificarExpediente(Expediente expediente)
    {
        throw new NotImplementedException();
    }
}
