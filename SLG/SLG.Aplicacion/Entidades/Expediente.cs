namespace SLG.Aplicacion;

public class Expediente{
    public int id {get; set;}
    public String? caratula {get; set;}
    public DateTime fechaCreacion {get; set;}
    public DateTime ultModificacion {get; set;}
    public int ultModificacionID {get; set;}
    public EstadoExpediente estado {get; set;}
    public List<Tramite>? Tramite {get; set;}


    public Expediente(){
        //vacio
    }

    public Expediente(String car){
        caratula=car;
        ultModificacionID= -1;
        estado=0;
    }
}