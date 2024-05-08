namespace SLG.Repositorios;

public class SecuenciaExpedienteTXT
{
    readonly string nombreArch="SecuenciaExp.txt";
    private int contId;

    public int LeerID()
    {
        using StreamReader sr= new StreamReader(nombreArch);
        int auxID=int.Parse(sr.ReadLine() ?? "-1"); // try catch para verificar si ya existe secuenciaexp.txt, si no existe crear
        using StreamWriter sw = new StreamWriter(nombreArch);
        auxID++;
        sw.WriteLine(auxID.ToString(),false);
        return auxID;
    }



}