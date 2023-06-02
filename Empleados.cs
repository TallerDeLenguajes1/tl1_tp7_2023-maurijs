namespace EspacioEmpleados;

public enum Cargos  //defino variables nuevas con valores discretos(1, 2, 3, ...)
{
    Auxiliar,
    Ingeniero,
    Especialista,
    Investigador
}
//get (sirve para obtener el dato)

public class Empleado
{
    // se declaran como propiedades automáticas, pero en realidad representan atributos de la clase Empleado.
    public string Nombre { get; set; }
    public string Apellido{ get; set;}
    public DateTime FechaNacimiento { get; set;}
    public char EstadoCivil { get; set;}
    public char Genero { get; set;} 
    public DateTime FechaIngreso { get; set;}
    public double SueldoBasico { get; set;}
    public Cargos Cargo { get; set; }

    public int Antiguedad()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan diferencia = fechaActual - FechaIngreso;
            return diferencia.Days / 365; // Retorna la antigüedad en años
        }

    public int Edad()
    {
        DateTime fechaActual = DateTime.Now;
        TimeSpan diferencia = fechaActual - FechaNacimiento;
        return (int)(diferencia.Days/365); // Retorna la edad en años
    }

    public int JubilacionTiempoFaltante()
    {
        int aniosRestantes;
        DateTime fechaActual = DateTime.Now;
        TimeSpan aniosTrabajados = fechaActual - FechaIngreso;
        if (Genero == 'M') {
            aniosRestantes = 65 - (int)(aniosTrabajados.Days/365);
        } else { 
            aniosRestantes = 60 - (int)(aniosTrabajados.Days/365);
        }
        return aniosRestantes;
    }
    /*Salario es una propiedad que utiliza metodos auxiliares. En este caso, Salario es una propiedad y no un atributo porque su valor se calcula dinámicamente utilizando métodos auxiliares y otros atributos de la clase Empleado. La propiedad Salario proporciona una forma conveniente de acceder y obtener el valor calculado del salario sin tener que llamar directamente a los métodos auxiliares cada vez. La diferencia entre un atributo y una propiedad en C# es que un atributo es una variable que almacena datos directamente,    mientras que una propiedad proporciona un mecanismo para acceder, establecer o calcular un valor asociado a un atributo.*/
    public double Salario
    {
        /*el bloque get realiza los cálculos necesarios para obtener el salario actualizado y lo devuelve como resultado. Esto permite obtener el salario actualizado sin necesidad de llamar directamente al método CalcularAdicional(), sino accediendo a la propiedad Salario*/
        get
        {
            double adicional = CalcularAdicional();
            return SueldoBasico + adicional;
        }
    }
    // Metodos auxiliares, son privados ya que es un calculo interno
    private double CalcularAdicional()
    {
        double porcentajeAntiguedad = CalcularPorcentajeAntiguedad();
        double porcentajeCargo = CalcularPorcentajeCargo();

        double adicional = SueldoBasico * porcentajeAntiguedad;
        adicional += adicional * porcentajeCargo;

        if (EstadoCivil == 'C')
        {
            adicional += 15000;
        }

        return adicional;
    }

    private double CalcularPorcentajeAntiguedad()
    {
        int antiguedad = Antiguedad();
        double porcentaje = 0;

        if (antiguedad <= 20)
        {
            porcentaje = antiguedad / 100;
        }
        else
        {
            porcentaje = 0.25;
        }

        return porcentaje;
    }

    private double CalcularPorcentajeCargo()
    {
        double porcentaje = 1;

        if (Cargo == Cargos.Ingeniero || Cargo == Cargos.Especialista)
        {
            porcentaje = 0.5;
        }

        return porcentaje;
    }

    //constructor
    public Empleado(string nombre, string apellido, DateTime fechaNacimiento, char estadoCivil, char genero, DateTime fechaIngreso, double sueldoBasico, Cargos cargo)
    {
        Nombre = nombre;
        Apellido = apellido;
        FechaNacimiento = fechaNacimiento;
        EstadoCivil = estadoCivil;
        Genero = genero;
        FechaIngreso = fechaIngreso;
        SueldoBasico = sueldoBasico;
        Cargo = cargo;
    }

    public void MostrarDatos()
    {
        Console.WriteLine("Datos del empleado:");
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Apellido: " + Apellido);
        Console.WriteLine("Fecha de Nacimiento: " + FechaNacimiento.ToShortDateString());//Fecha en formato dd/mm/aaaa
        Console.WriteLine("Estado Civil: " + EstadoCivil);
        Console.WriteLine("Género: " + Genero);
        Console.WriteLine("Fecha de Ingreso: " + FechaIngreso.ToShortDateString());
        Console.WriteLine("Sueldo Básico: " + SueldoBasico);
        Console.WriteLine("Cargo: " + Cargo);
    }

}