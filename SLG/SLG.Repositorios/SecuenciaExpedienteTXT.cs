namespace SLG.Repositorios;

public class SecuenciaExpedienteTXT
{
    readonly string nombreArch="SecuenciaExp.txt";

    public int LeerID()
    {
        using StreamReader sr= new StreamReader(nombreArch);
        int auxID=int.Parse(sr.ReadLine() ?? "-1");
        using StreamWriter sw = new StreamWriter(nombreArch);
        auxID++;
        sw.WriteLine(auxID.ToString(),false);
        return auxID;
    }



}