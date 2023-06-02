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
   public string Nombre { get; set;}
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

    public double Salario() 
    {
        double salario, Adicional;
        int antiguedad = Antiguedad();

        if (antiguedad <= 20)
        {
            Adicional = SueldoBasico*(antiguedad /100);    
        } else
        {
            Adicional = SueldoBasico * 0.25;
        }

        if (Cargo == Cargos.Especialista || Cargo == Cargos.Ingeniero)
        {
            Adicional += Adicional * 0.5;
        }

        if (EstadoCivil == 'S')
        {
            Adicional += 15000;
        }
        
        salario = SueldoBasico + Adicional;
        return salario;
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

}