using Microsoft.EntityFrameworkCore;
using SLG.Aplicacion;
using System.Linq;
namespace SLG.Repositorios;

public class ExpedienteRepositorio(SLGContext context) : IExpedienteRepositorio{
    public void ModificarExpediente(Expediente expediente)
    {
        var aux = context.Expedientes.Where(e => e.id == expediente.id).SingleOrDefault();
        if (aux != null){
            aux.caratula=expediente.caratula;
            aux.ultModificacionID=expediente.ultModificacionID;
            aux.ultModificacion=expediente.ultModificacion;
        } else throw new RepositorioException();
        context.SaveChanges();
    }
    public void AgregarExpediente(Expediente expediente)
    {
        context.Add(expediente);
        context.SaveChanges();
    }


    public Expediente ConsultaPorId(int expedienteId)
    {   
        var aux= context.Expedientes.Where(e => e.id==expedienteId).SingleOrDefault();
        if (aux == null) {
            throw new RepositorioException();
        }
        return aux;
    }



    public List<Expediente> ConsultaTodos()
    {
        var aux = context.Expedientes.Select(n => n).ToList();
        if (aux == null){
            throw new RepositorioException();
        }
        return aux;
    }

    public void EliminarExpediente(Expediente expediente)
    {
        var aux = context.Expedientes.Where(e => e.id==expediente.id).
                Include(e => e.Tramite).
                SingleOrDefault();
        if (aux != null){
            context.Remove(aux);
        } else throw new RepositorioException();
        context.SaveChanges();
    }    
}