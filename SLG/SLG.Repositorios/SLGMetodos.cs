using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SLG.Aplicacion;

namespace SLG.Repositorios;

public class SLGMetodos(SLGContext context) : IContextDB
{
    public void AgregarExpediente(Expediente expediente)
    {
        context.Add(expediente);
        context.SaveChanges();
    }

    public void AgregarTramite(Tramite tramite)
    {
        context.Add(tramite);
        context.SaveChanges();
    }

    public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta)
    {
        var aux= context.Tramites.Where(t => t.tipoTramite==etiqueta).ToList();
        if (aux == null){
            throw new RepositorioException();
        }
        return aux;
    }
    public Expediente ConsultaPorId(int expedienteId)
    {   
        var aux= context.Expedientes.Where(e => e.id==expedienteId).SingleOrDefault();
        if (aux == null) {
            throw new RepositorioException();
        }
        return aux;
    }

    public List<Tramite> ConsultaPorIdExpediente(int idExpediente)
    {
        var aux = context.Tramites.Where(t => t.ExpedienteId==idExpediente).ToList();
        if (aux == null){
            throw new RepositorioException();
        }
        return aux;   
    }

    public List<Expediente> ConsultaTodos()
    {
<<<<<<< HEAD
        throw new NotImplementedException();
=======
        var aux = context.Expedientes.Select(n => n).ToList();
        if (aux == null){
            throw new RepositorioException();
        }
        return aux
>>>>>>> b7cffc19f5a320d172146e276e0d642d6efcd329
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

    public void EliminarTramite(Tramite tramite)
    {
        var aux = context.Tramites.Where(t => t.id == tramite.id);
        if (aux != null){
            context.Remove(aux);
        } else throw new RepositorioException();
        context.SaveChanges();
    }

    public void ModificarExpediente(Expediente expediente)
    {
        var aux = context.Expedientes.Where(e => e.id == expediente.id).SingleOrDefault();
        if (aux != null){
            aux = expediente;
        } else throw new RepositorioException();
        context.SaveChanges();
    }

    public void ModificarTramite(Tramite tramite)
    {
        var aux = context.Tramites.Where(t => t.id == tramite.id).SingleOrDefault();
        if (aux != null){
            aux = tramite;
        } else throw new RepositorioException();
        context.SaveChanges();
    }
}