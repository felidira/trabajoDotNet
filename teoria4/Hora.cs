public class Hora(int _hora, int _min, int _sec){

    public Hora(double x) : this((int)x, ){}
    public void Imprimir(){
        Console.WriteLine($"{_hora} horas, {_min} minutos, {_sec} segundos");
    }
}