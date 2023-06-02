using EspacioEmpleados;

Empleado[] empleado = new Empleado[3];

int d, m, a, opcion;
Cargos cargo = Cargos.Investigador;
double sueldoBasico, MontoTotal = 0;
string nombre, apellido;
DateTime fechaIngreso = DateTime.Now, fechaNacimiento = DateTime.Now;
char EstadoCivil, genero;
ConsoleKeyInfo caracter; //Se utiliza para recibir un caracter

for (int i = 0; i < 3; i++)
{
    Console.WriteLine("Ingrese nombre:\n");
    nombre = Console.ReadLine();
    Console.WriteLine("Ingrese apellido:\n");
    apellido = Console.ReadLine();
    Console.WriteLine("Ingrese Estado Civil: C = Casado, S = Soltero\n");
    //Ingresa el caracter
    caracter = Console.ReadKey();
    EstadoCivil = caracter.KeyChar;

    Console.WriteLine("Ingrese genero: M = masculino, F = femenino\n");
    caracter = Console.ReadKey();
    genero = caracter.KeyChar;

    Console.WriteLine("Ingrese cargo:\n0-Auxiliar\n1-Ingeniero\n2-Especialista\n3-Investigador");
    while (!int.TryParse(Console.ReadLine(), out opcion) && opcion < 0 && opcion > 4)
    {
        Console.WriteLine("\nLa opcion ingresada no es valida, ingrese nuevamente\n");
    }
    switch (opcion)
    {
        case 0:
            cargo = Cargos.Auxiliar;
            break;
        case 1:
            cargo = Cargos.Ingeniero;
            break;
        case 2:
            cargo = Cargos.Especialista;
            break;
        case 3:
            cargo = Cargos.Investigador;
            break;
    }

    Console.WriteLine("Ingrese sueldo basico:\n");
    while (!double.TryParse(Console.ReadLine(), out sueldoBasico) && sueldoBasico > 0)
    {
        Console.WriteLine("\nEl valor ingresado no es valido, ingrese nuevamente\n");
    }

    Console.WriteLine("Ingrese fecha de ingreso: dd/mm/aaaa");
    while(!int.TryParse(Console.ReadLine(), out d) && !int.TryParse(Console.ReadLine(), out m) && !int.TryParse(Console.ReadLine(), out a))
    {
        fechaIngreso = new DateTime(a, d, m);
    }
    Console.WriteLine("Ingrese fecha de nacimiento: dd/mm/aaaa");
    while(!int.TryParse(Console.ReadLine(), out d) && !int.TryParse(Console.ReadLine(), out m) && !int.TryParse(Console.ReadLine(), out a))
    {
        fechaNacimiento = new DateTime(a, d, m);
    }
    empleado[i] = new Empleado(nombre, apellido, fechaNacimiento, EstadoCivil, genero, fechaIngreso, sueldoBasico, cargo);

    MontoTotal = MontoTotal + empleado[i].Salario;
}

Console.WriteLine("\nEl monto total en concepto de salarios es: " + MontoTotal);

if (empleado[0].Salario > empleado[1].Salario && empleado[2].Salario > empleado[1].Salario )
{
    Console.WriteLine("\nDatos del empleado mas proxima a jubilarse\n");   
    empleado[1].MostrarDatos();
} else if (empleado[1].Salario > empleado[2].Salario && empleado[0].Salario > empleado[2].Salario ) 
{
    Console.WriteLine("\nDatos del empleado mas proxima a jubilarse\n");   
    empleado[2].MostrarDatos();
} else if (empleado[1].Salario > empleado[0].Salario && empleado[2].Salario > empleado[0].Salario )
{
    Console.WriteLine("\nDatos del empleado mas proxima a jubilarse\n");   
    empleado[0].MostrarDatos();
} else
{
    Console.WriteLine("No hay un empleado mas proximo a jubilarse");   
}



//<Nullable>disable</Nullable> en .csproj asi no deba poner ? en string