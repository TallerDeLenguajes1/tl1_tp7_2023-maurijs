using EspacioCalculadora;

Calculadora Calcula = new Calculadora();
float num1;
int opcion;
Console.WriteLine("Seleccione la operacion a realizar:\n1-Sumar\n2-Restar\n3-Multiplicar\n4-Dividir\n5-Reiniciar\n6-Salir");


while (int.TryParse(Console.ReadLine(), out opcion) && opcion != 6 )
{
    if (opcion == 5)
    {
        Calcula.Limpiar();
    } else 
    {
        Console.WriteLine("\nIngrese el numeros a operar:\n");
        if (float.TryParse(Console.ReadLine(), out num1))
        {    
            switch (opcion)
            {
                case 1:
                    Calcula.Sumar(num1); //ya que las funciones de la clase calculadora son de tipo void, el dato se actualiza
                                        // dentro de la clase
                    break;
                case 2:
                    Calcula.Restar(num1);
                    break;
                case 3:
                    Calcula.Multiplicar(num1);
                    break;
                case 4:
                    Calcula.Dividir(num1);
                    break;           
            }       
        }
    }

    Console.WriteLine("\nResultado: " + Calcula.Resultado + "\n");
    Console.WriteLine("Seleccione la operacion a realizar:\n1-Sumar\n2-Restar\n3-Multiplicar\n4-Dividir\n5-Reiniciar\n6-Salir");
}

if (opcion == 6)
{
    Console.WriteLine("\nSaliendo del programa\n");
} else
{
    Console.WriteLine("\nOpcion ingresada invalida\n");
}







