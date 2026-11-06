using System;

Console.WriteLine("SISTEMA DE CONTROL DE MOTORES");
Console.WriteLine();

// Crear un objeto de la clase derivada MotorCD
MotorCD motorCD1 = new MotorCD();

// Capturar la información del objeto por medio del usuario
Console.Write("Ingrese el identificador del motor: ");
motorCD1.Identificador = Console.ReadLine() ?? "Sin identificador";

Console.Write("Ingrese la temperatura del motor: ");
motorCD1.Temperatura = Convert.ToDouble(Console.ReadLine());

Console.Write("Ingrese la corriente del motor: ");
motorCD1.Corriente = Convert.ToDouble(Console.ReadLine());

Console.Write("Ingrese la velocidad del motor en rpm: ");
motorCD1.Velocidad = Convert.ToDouble(Console.ReadLine());

// Capturar la propiedad propia de MotorCD
Console.Write("Ingrese el voltaje del motor: ");
motorCD1.Voltaje = Convert.ToDouble(Console.ReadLine());

// Mostrar resultados
Console.WriteLine();
Console.WriteLine("DATOS DEL MOTOR");
Console.WriteLine($"Motor: {motorCD1.Identificador}");
Console.WriteLine($"Temperatura: {motorCD1.Temperatura} °C");
Console.WriteLine($"Corriente: {motorCD1.Corriente} A");
Console.WriteLine($"Velocidad: {motorCD1.Velocidad} rpm");
Console.WriteLine($"Voltaje: {motorCD1.Voltaje} V");

Console.WriteLine($"Estado: {motorCD1.ObtenerEstado()}");
Console.WriteLine($"Revisión de temperatura: {motorCD1.RevisarTemperatura()}");


// CLASE BASE
class Motor
{
    // Propiedades comunes
    public string Identificador { get; set; } = "";
    public double Temperatura { get; set; }
    public double Corriente { get; set; }
    public double Velocidad { get; set; }

    // Método para determinar el estado
    public string ObtenerEstado()
    {
        if (Velocidad > 0)
            return "Motor en marcha";
        else
            return "Motor detenido";
    }

    // Método para revisar la temperatura
    public string RevisarTemperatura()
    {
        if (Temperatura > 70)
            return "ALERTA: Temperatura elevada";

        return "Temperatura normal";
    }
}


// CLASE DERIVADA
class MotorCD : Motor
{
    // Propiedad propia de la clase derivada
    public double Voltaje { get; set; }
}