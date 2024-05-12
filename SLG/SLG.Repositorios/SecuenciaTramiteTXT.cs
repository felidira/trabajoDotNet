namespace SLG.Repositorios;

public class SecuenciaTramiteTXT
{
    readonly string nombreArch="SecuenciaTramite.txt";
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