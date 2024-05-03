using System.Text;

class Cuenta (double _monto, int _titularDNI, string _titularNombre)
{
    public Cuenta() : this(0, 0, "No especificado"){}
    public Cuenta(int dni) : this(0, dni, "No especificado"){}

    public Cuenta(string st) : this(0, 0, st){}

    public Cuenta(string st, int dni) : this(0, dni, st){}

    public void Imprimir(){
        StringBuilder st= new StringBuilder($"Nombre: {_titularNombre}, DNI: ");
        st + (_titularDNI==0) ? "No especificado" : _titularDNI;
    }
}