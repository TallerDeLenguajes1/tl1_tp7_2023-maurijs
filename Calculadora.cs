namespace EspacioCalculadora;
public class Calculadora
{
    private double dato; //5 references indica la cantidad de veces que se utiliza esa variable
                         // tocar foquito encapsular dato 

    public double Resultado { get => dato; }

    /* public double Resultado   forma alternativa
        {
        get { return dato; }
        }
    */

    public void Sumar(double termino)
    {
        dato += termino;
    }

    public void Restar(double termino)
    {
        dato -= termino;
    }

    public void Multiplicar(double termino)
    {
        dato *= termino;
    }

    public void Dividir(double termino)
    {
        if (termino != 0)
        {
            dato /= termino;
        }
        else
        {
            Console.WriteLine("No se puede dividir por cero");
        }
    }

    public void Limpiar()
    {
        dato = 0;
    }
}
