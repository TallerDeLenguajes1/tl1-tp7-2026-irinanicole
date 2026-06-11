namespace EspacioEmpleado
{
    public enum Cargos
    {
        Auxiliar,       // 0
        Administrativo, // 1
        Ingeniero,      // 2
        Especialista,   // 3
        Investigador    // 4
    }
    public class Empleado
    {
        private string nombre;
        private string apellido;
        private DateTime fechaNacimiento;
        private char estadoCivil;
        private DateTime fechaIngreso;
        private double sueldo;
        private Cargos cargo;

        public string Nombre { get => nombre; }
        public string Apellido { get => apellido; }
        public DateTime FechaNacimiento { get => fechaNacimiento; }
        public char EstadoCivil { get => estadoCivil; }
        public DateTime FechaIngreso { get => fechaIngreso; }
        public double Sueldo { get => CalcularSalario(); }
        public Cargos Cargo { get => cargo; }

        public Empleado(string nombre, string apellido, DateTime fechaNacimiento, char estadoCivil, DateTime fechaIngreso, double sueldo, Cargos cargo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.estadoCivil = estadoCivil;
            this.fechaIngreso = fechaIngreso;
            this.sueldo = sueldo;
            this.cargo = cargo;
        }

        /* 
        a. Calcular: 
        */
        /* i. La antigüedad del empleado en la empresa. */ 
        public int Antiguedad()
        {
            return ( DateTime.Now.Subtract(fechaIngreso).Days / 365 );
        }
        /* ii. La edad del empleado */
        public int Edad()
        {
            return ( DateTime.Now.Subtract(fechaNacimiento).Days / 365 );
        }
        /* iii. La cantidad de años que le falta al empleado para poder jubilarse, considerando que la edad de jubilación es de 65 */
        public int AniosRestantesParaJubilarse()
        {
            return ( 65 - Edad() );
        }

        /* 
        b. Calcular el salario, de acuerdo a la fórmula: 
        Salario = Sueldo Básico + Adicional. 
        (el Adicional contempla la antigüedad en años, el cargo y si es casado)
        */
        public double CalcularSalario()
        {
            int aniosAntiguedad = Antiguedad();
            double adicional = 0;

            /* 
            i) 1 % del sueldo básico por cada año de antigüedad hasta 
            los 20 años, a partir de este, el porcentaje se fija en 25%
            */
            if ( aniosAntiguedad >= 20 )
            {
                adicional = 0.25 * sueldo;
            }
            else if ( aniosAntiguedad >= 1 && aniosAntiguedad < 20 )
            {
                adicional = (0.01 * aniosAntiguedad) * sueldo;
            }

            /*
            ii) Si el cargo es Ingeniero o Especialista, el Adicional 
            se incrementa en un 50%
            */
            if ( cargo == Cargos.Especialista || cargo == Cargos.Ingeniero )
            {
                adicional = adicional * 1.5;
            }

            /*
            iii) Si es casado al Adicional se le aumenta $150.000
            */
            if ( estadoCivil == 'C' )
            {
                adicional = adicional + 150000;
            }

            return ( sueldo + adicional );
        }
    }

}