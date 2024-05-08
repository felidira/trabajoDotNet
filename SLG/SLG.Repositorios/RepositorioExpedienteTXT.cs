﻿using SLG.Aplicacion;
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

    public Expediente ConsultaPorId(int id)
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

    public void CambiarEstadoExpediente(int ExpedienteId, EstadoExpediente nuevoEstado)
    {
        Expediente exp=ConsultaPorId(ExpedienteId);
        exp.estado=nuevoEstado;
        ModificarExpediente(exp);
    }

    public void ModificarExpediente(Expediente expediente)
    {
        throw new NotImplementedException();
    }
}