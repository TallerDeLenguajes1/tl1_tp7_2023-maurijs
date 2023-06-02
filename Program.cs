using EspacioEmpleados;

Empleado empleado = new Empleado();

int d, m, a;
float sueldo;
string nombre, apellido;
Console.WriteLine("Ingrese el dia, mes y anio: dd/mm/aaaa");
if(int.TryParse(Console.ReadLine(), out d) && int.TryParse(Console.ReadLine(), out m) && int.TryParse(Console.ReadLine(),out a))
{
    DateTime Fecha = new DateTime(a, d, m);
    DateTime Hoy = DateTime.Now;
    
}

Console.WriteLine("Ingrese Nombre y Apellido");
nombre = Console.ReadLine();
apellido = Console.ReadLine();

Console.WriteLine("Ingrese la edad");
if(float.TryParse(Console.ReadLine(), out sueldo))
{
    empleado.Sueldo = sueldo;
}

//<Nullable>disable</Nullable> en .csproj asi no deba poner ? en string