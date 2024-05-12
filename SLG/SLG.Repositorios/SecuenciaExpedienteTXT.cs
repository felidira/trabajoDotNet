namespace SLG.Repositorios;

public class SecuenciaExpedienteTXT
{
    readonly string nombreArch="SecuenciaExp.txt";

    public int LeerID()
    {
        int auxID;
        using (StreamReader sr= new StreamReader(nombreArch)){
            auxID=int.Parse(sr.ReadLine() ?? "0");
        }
        using StreamWriter sw = new StreamWriter(nombreArch);
        auxID++;
        sw.WriteLine(auxID.ToString(),false);
        return auxID;
    }



}