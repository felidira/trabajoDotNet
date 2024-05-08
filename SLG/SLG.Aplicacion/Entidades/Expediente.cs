namespace SLG.Aplicacion;

public class Expediente{
    public int id {get;}
    public String? caratula {get;}
    public DateTime fechaCreacion {get;}
    public DateTime ultModificacion {get; set;}
    public int ultModificacionID {get; set;}
    public EstadoExpediente estado {get; set;}

    public Expediente(String car){
        caratula=car;
        fechaCreacion=DateTime.Now;
        ultModificacion=fechaCreacion;
        ultModificacionID= -1;
        estado=0;
    }
}