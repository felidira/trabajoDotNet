namespace SLG.Aplicacion;

public class Tramite{
    public int id {get; set;}
    public int ExpedienteId {get; set;}
    public EtiquetaTramite tipoTramite {get; set;}
    public String? contenido {get; set;}
    public DateTime fechaCreacion {get; set;}
    public DateTime ultModificacion {get;set;}
    public int ultModificacionID {get;set;}

    public Tramite()
    {
        //vacío
    }

    public Tramite(int id,int eid, String cont){
        this.id=id;
        ExpedienteId=eid;
        tipoTramite=0;
        contenido=cont;
        fechaCreacion=DateTime.Now;
        ultModificacion=fechaCreacion;
        ultModificacionID=-1;
    }
}