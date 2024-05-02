using SLG.Aplicacion;
namespace SLG.Repositorios;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    readonly String nombreArch= "archivo.txt";
    public void AgregarExpediente(Expediente expediente)
    {
        using StreamWriter sw = new StreamWriter(nombreArch,true);
        sw.WriteLine(expediente.id);
        sw.WriteLine(expediente.caratula);
        sw.WriteLine(expediente.fechaCreacion);
        sw.WriteLine(expediente.ultModificacion);
        sw.WriteLine(expediente.ultModificacionID);
        sw.WriteLine(expediente.estado);
    }

    public void ConsultaPorId()
    {
        throw new NotImplementedException();
    }

    public void ConsultaTodos()
    {
        throw new NotImplementedException();
    }

    public void EliminarExpediente()
    {
        throw new NotImplementedException();
    }

    public void ModificarExpediente()
    {
        throw new NotImplementedException();
    }
}
