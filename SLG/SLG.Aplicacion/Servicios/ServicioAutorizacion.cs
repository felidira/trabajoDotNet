namespace SLG.Aplicacion;
public class ServicioAutorizacion : IServicioAutorizacion
{
    public bool PoseeElPermiso(String permisos, Permiso Aposeer)
    {
        bool tiene = false;
        string[] aux = permisos.Split(',');
        foreach(string auxStr in aux){
            if(auxStr.Equals(Aposeer)) tiene=true;
        }
        return tiene;
    }
}