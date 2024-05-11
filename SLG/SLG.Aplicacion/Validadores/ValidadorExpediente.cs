namespace SLG.Aplicacion;

public class ValidadorExpediente{

    public bool ValidarExp(Expediente expediente)
    {
        return (expediente.caratula != null);
    }
}