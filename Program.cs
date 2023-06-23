using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear instancia del modelo
        Modelo modelo = new Modelo();

        // Crear instancia de la vista
        Vista vista = new Vista();

        // Crear instancia del controlador
        Controlador controlador = new Controlador(modelo, vista);

        // Agregar tareas desde el teclado
        string tarea = "";
        do
        {
            Console.WriteLine("Ingrese una tarea (o 'q' para salir):");
            tarea = Console.ReadLine();
            if (tarea != "q")
            {
                controlador.AgregarTarea(tarea);
            }
        } while (tarea != "q");

        // Mostrar lista completa de tareas
        vista.MostrarListaCompleta(controlador.ObtenerTareas());

        Console.ReadLine();
    }
}

class Modelo
{
    private List<string> tareas;

    public Modelo()
    {
        tareas = new List<string>();
    }

    public List<string> ObtenerTareas()
    {
        return tareas;
    }

    public void AgregarTarea(string tarea)
    {
        tareas.Add(tarea);
    }
}

class Vista
{
    public void MostrarListaCompleta(List<string> tareas)
    {
        Console.WriteLine("Lista completa de tareas:");
        foreach (string tarea in tareas)
        {
            Console.WriteLine(tarea);
        }
        Console.WriteLine();
    }
}

class Controlador
{
    private Modelo modelo;
    private Vista vista;

    public Controlador(Modelo modelo, Vista vista)
    {
        this.modelo = modelo;
        this.vista = vista;
    }

    public List<string> ObtenerTareas()
    {
        return modelo.ObtenerTareas();
    }

    public void AgregarTarea(string tarea)
    {
        modelo.AgregarTarea(tarea);
    }
}
