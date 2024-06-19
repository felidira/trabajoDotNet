using System.Linq.Expressions;
using SLG.Aplicacion;

namespace SLG.Repositorios;

public class SLGMetodos(SLGContext context) : IContextDB
{
    public void AgregarExpediente(Expediente expediente)
    {
        context.Add(expediente);
    }

    public void AgregarTramite(Tramite tramite)
    {
        context.Add(tramite);
    }

    public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta)
    {
        var aux= context.Tramites.Where(t => t.tipoTramite==etiqueta).ToList();
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
        return aux;   
    }

    public List<Expediente> ConsultaTodos()
    {
        
    }

    public void EliminarExpediente(Expediente expediente)
    {
        throw new NotImplementedException();
    }

    public void EliminarTramite(Tramite tramite)
    {
        throw new NotImplementedException();
    }

    public void ModificarExpediente(Expediente expediente)
    {
        throw new NotImplementedException();
    }

    public void ModificarTramite(Tramite tramite)
    {
        throw new NotImplementedException();
    }
}