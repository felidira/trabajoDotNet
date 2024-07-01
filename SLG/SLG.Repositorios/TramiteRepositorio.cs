using Microsoft.EntityFrameworkCore;
using SLG.Aplicacion;
using System.Linq;
namespace SLG.Repositorios;

public class TramiteRepositorio(SLGContext context) : ITramiteRepositorio{
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
    public List<Tramite> ConsultaPorIdExpediente(int idExpediente)
    {
        var aux = context.Tramites.Where(t => t.ExpedienteId==idExpediente).ToList();
        if (aux == null){
            throw new RepositorioException();
        }
        return aux;   
    }
    public void EliminarTramite(Tramite tramite)
    {
        var aux = context.Tramites.Where(t => t.id == tramite.id).SingleOrDefault();
        if (aux != null){
            context.Remove(aux);
        } else throw new RepositorioException();
        context.SaveChanges();
    }

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

    public void ModificarTramite(Tramite tramite)
    {
        var aux = context.Tramites.Where(t => t.id == tramite.id).SingleOrDefault();
        if (aux != null){
            aux.tipoTramite = tramite.tipoTramite;
            aux.contenido = tramite.contenido;
            aux.ultModificacion= tramite.ultModificacion;
            aux.ultModificacionID = tramite.ultModificacionID;
        } else throw new RepositorioException();
        context.SaveChanges();
    }
    public List<Tramite> ConsultaTodosTramite()
    {
        var aux = context.Tramites.Select(n => n)
                .ToList();
        if (aux == null){
            throw new RepositorioException();
        }
        return aux;
    }    
}