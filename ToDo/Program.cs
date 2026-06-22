using System.Security.Cryptography;
using EspacioTarea;

internal class Program()
{
    private static void Main()
    {
        
        string [ ] Descripciones = {"Hacer el footer", "Hacer el Header", "Cargar imagenes a la DB", "Diseñar Main", "Desarrollar Calculadora"};

        List <Tarea> tareasPendientes = new List<Tarea>();

        int N = 5, desc, dur;
        Random random = new Random();
        for (int i = 0; i < N; i++)
        {
            desc = random.Next(5);
            dur = random.Next(10, 101);
            tareasPendientes.Add(new Tarea {TareaID = i + 1, Descripcion = Descripciones[desc], Duracion = dur});
        }
        Console.WriteLine(tareasPendientes[1].Duracion);

    }
}