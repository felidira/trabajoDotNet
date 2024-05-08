namespace SLG.Repositorios;

public class SecuenciaTramiteTXT
{
    readonly string nombreArch="SecuenciaTramite.txt";
    public int LeerID()
    {
        using StreamReader sr= new StreamReader(nombreArch);
        int auxID=int.Parse(sr.ReadLine()); 
        using StreamWriter sw = new StreamWriter(nombreArch);
        auxID++;
        sw.WriteLine(auxID.ToString(),false);
        return auxID;
    }



}