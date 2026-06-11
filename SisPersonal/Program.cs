using EspacioEmpleado;

/* c. Cargue los datos para 3 empleados en un arreglo de tipo empleados. */
int cant_empleados = 3;
Empleado[] empleados = new Empleado[cant_empleados];

// Carga del arreglo
empleados[0] = new Empleado("Juan", "Perez", new DateTime(1975, 5, 10, 4, 25, 39), 'C', 
                            new DateTime(2011, 5, 15), 650000, Cargos.Especialista);
empleados[1] = new Empleado("Mario", "Paz", new DateTime(1985, 9, 23, 15, 8, 13), 'S', 
                            new DateTime(2020, 6, 5), 350000, Cargos.Ingeniero);
empleados[2] = new Empleado("Guillermo", "Jimenez", new DateTime(2000, 6, 3, 1, 38, 56), 'C', 
                            new DateTime(2018, 3, 18), 150000, Cargos.Administrativo);

// Muestro por pantalla todos los empleados
Console.WriteLine("\nLista de empleados");
foreach (Empleado empleado in empleados)
{
    Console.WriteLine("\n--------------------------------");
    Console.WriteLine($"Nombre: {empleado.Nombre}");
    Console.WriteLine($"Apellido: {empleado.Apellido}");
    Console.WriteLine($"Fecha de Nacimiento: {empleado.FechaNacimiento}");
    Console.WriteLine($"Estado civil: {empleado.EstadoCivil}");
    Console.WriteLine($"Fecha de Ingreso a la empresa: {empleado.FechaIngreso}");
    Console.WriteLine($"Sueldo: {empleado.Sueldo}");
    Console.WriteLine($"Cargo: {empleado.Cargo}");
    Console.WriteLine("--------------------------------");
}


/* d. Obtener el Monto Total de lo que se paga en concepto de Salarios. */
double montoTotal = 0;
foreach (Empleado empleado in empleados)
{
    montoTotal = montoTotal + empleado.CalcularSalario();
}
Console.WriteLine($"\nMonto Total de lo que se paga en concepto de Salarios: {montoTotal}\n");


/* Muestre por pantalla los datos del empleado que esté más próximo a jubilarse 
(incluyendo los datos del apartado 2.a y el salario correspondiente). */
int aniosJubilacionMasProximo = 65;
string NombreEmpleadoMasProximoAJubilarse = " ";
foreach (Empleado empleado in empleados)
{
    int aniosRestantesParaJubilarse = empleado.AniosRestantesParaJubilarse();
    if (aniosJubilacionMasProximo > aniosRestantesParaJubilarse)
    {
        aniosJubilacionMasProximo = aniosRestantesParaJubilarse;
        NombreEmpleadoMasProximoAJubilarse = empleado.Nombre;
    }
}
if (!string.IsNullOrWhiteSpace(NombreEmpleadoMasProximoAJubilarse))
{
    Console.WriteLine("\nEmpleado más proximo a jubilarse:");
    foreach (Empleado empleado in empleados)
    {
        if (empleado.Nombre == NombreEmpleadoMasProximoAJubilarse)
        {
            Console.WriteLine($"Nombre: {empleado.Nombre}");
            Console.WriteLine($"Apellido: {empleado.Apellido}");
            Console.WriteLine($"Fecha de Nacimiento: {empleado.FechaNacimiento}");
            Console.WriteLine($"Estado civil: {empleado.EstadoCivil}");
            Console.WriteLine($"Fecha de Ingreso a la empresa: {empleado.FechaIngreso}");
            Console.WriteLine($"Sueldo: {empleado.Sueldo}");
            Console.WriteLine($"Cargo: {empleado.Cargo}");
            break;
        }
    }
}
else
{
    Console.WriteLine("\nOcurrió un error buscando al empleado más proximo a jubilarse.");
}
