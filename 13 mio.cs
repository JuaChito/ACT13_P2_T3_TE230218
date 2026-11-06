using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("SISTEMA DE MONITOREO DE MOTORES PARA EJERCICIO 13");
        Console.WriteLine();

        // Lista para guardar varios objetos de la clase principal Motor (y sus derivados)
        List<Motor> motores = new List<Motor>();

        {
            Console.WriteLine();
            Console.WriteLine($"Motor {i}");

            // 1. Preguntar qué tipo de motor se va a crear
            Console.WriteLine("Seleccione el tipo de motor:");
            Console.WriteLine("1. Motor DC");
            Console.WriteLine("2. Motor AC");
            Console.WriteLine("3. Servomotor");
            Console.Write("Opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            Motor motor; // Variable de la clase base

            // 2. Instanciar la clase derivada correspondiente
            switch (opcion)
            {
                case 1:
                    break;
                    motor = new Motores_DC();
                    break;
                case 2:
                    motor = new Motores_AC();
                    break;
                case 3:
                    motor = new Servomotores();
                default:
                    Console.WriteLine("Opción no válida. Registrando como Motor genér
            Console.Write("Ingrese la temperatura (°C): ");
            motor.Temperatura = Convert.ToDouble(Console.ReadLine());ico.");
                    motor = new Motor();
                    break;
            }

            // 3. Capturar las propiedades COMUNES (heredadas)
            Console.Write("Ingrese el identificador del motor: ");
            motor.Identificador = Console.ReadLine() ?? "Sin identificador";


            Console.Write("Ingrese la corriente (A): ");
            motor.Corriente = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese la velocidad (RPM): ");
            motor.Velocidad = Convert.ToDouble(Console.ReadLine());

            // 4. Capturar las propiedades ESPECÍFICAS según la clase instanciada
            if (motor is Motores_DC motorDC)
            {
                Console.Write("Ingrese el voltaje de operación (V): ");
                motorDC.Voltaje_op = Convert.ToDouble(Console.ReadLine());
            }
            else if (motor is Motores_AC motorAC)
            {
                Console.Write("Ingrese las fases de operación (ej. 1, 2, 3): ");
                motorAC.Fases_op = Convert.ToInt32(Console.ReadLine());
            }
            else if (motor is Servomotores servo)
            {
                Console.Write("Ingrese la posición angular (grados): ");
                servo.Posicion_angular = Convert.ToDouble(Console.ReadLine());
            }

            // Agregar el objeto a la lista
            motores.Add(motor);
        }

        // Mostrar resultados de todos los motores
        Console.WriteLine();
        Console.WriteLine("RESULTADOS");
        foreach (Motor m in motores)
        {
            Console.WriteLine();
            m.MostrarDatos(); // Automáticamente ejecutará el MostrarDatos() de la clase hija correspondiente
        }
    }
}

// 1. CLASE BASE
class Motor
{
    // Propiedades comunes
    public string Identificador { get; set; } = "";
    public double Temperatura { get; set; }
    public double Corriente { get; set; }
    public double Velocidad { get; set; }

    // Método para evaluar la temperatura
    public string EvaluarTemperatura()
    {
        if (Temperatura > 70)
        {
            return "TEMPERATURA ALTA (mayor a 70 °C)";
        }
        else
        {
            return "TEMPERATURA NORMAL";
        }
    }

    // Método para determinar si el motor está detenido o en marcha
    public string ObtenerEstadoMarcha()
    {
        if (Velocidad == 0)
        {
            return "DETENIDO";
        }
        else
        {
            return "EN MARCHA";
        }
    }

    // Usamos 'virtual' para permitir que las clases derivadas modifiquen este método
    public virtual void MostrarDatos()
    {
        Console.WriteLine($"Identificador: {Identificador}");
        Console.WriteLine($"Temperatura: {Temperatura:F1} °C");
        Console.WriteLine($"Corriente: {Corriente:F2} A");
        Console.WriteLine($"Velocidad: {Velocidad:F0} RPM");
        Console.WriteLine($"Estado de temperatura: {EvaluarTemperatura()}");
        Console.WriteLine($"Estado del motor: {ObtenerEstadoMarcha()}");
    }
}

// 2. CLASES DERIVADAS

class Motores_DC : Motor
{
    public double Voltaje_op { get; set; }

    // Usamos 'override' para extender la función MostrarDatos original
    public override void MostrarDatos()
    {
        base.MostrarDatos(); // Ejecuta el console.writeline de la clase principal
        Console.WriteLine($"Voltaje de Operación: {Voltaje_op} V (Motor DC)");
    }
}

class Motores_AC : Motor
{
    public int Fases_op { get; set; }

    public override void MostrarDatos()
    {
        base.MostrarDatos();
        Console.WriteLine($"Fases de Operación: {Fases_op} (Motor AC)");
    }
}

class Servomotores : Motor
{
    public double Posicion_angular { get; set; }

    public override void MostrarDatos()
    {
        base.MostrarDatos();
        Console.WriteLine($"Posición Angular: {Posicion_angular}° (Servomotor)");
    }
}