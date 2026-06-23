using System.Security.Cryptography;
using EspacioTarea;

internal class Program()
{
    private static void Main()
    {
        
        string [ ] Descripciones = {"Hacer el footer", "Hacer el Header", "Cargar imagenes a la DB", "Diseñar Main", "Desarrollar Calculadora"};

        List <Tarea> tareasPendientes = new List<Tarea>();
        List <Tarea> tareasRealizadas = new List<Tarea>();
        int N = 5, desc, dur;
        Random random = new Random();
        for (int i = 0; i < N; i++)
        {
            desc = random.Next(5);
            dur = random.Next(10, 101);
            tareasPendientes.Add(new Tarea {TareaID = i, Descripcion = Descripciones[desc], Duracion = dur});
        }
        Operar(tareasPendientes, tareasRealizadas);
    }

    static void MoverTareas(List <Tarea> tP, List<Tarea> tR)
    {
        bool continuar = true;
        string entrada, bandera;
        int ID;
        while (continuar)
        {
            do
            {
                Console.WriteLine("Ingrese el ID de la tarea que desea Finalizar: ");
                entrada = Console.ReadLine();
            } while (int.TryParse(entrada, out ID) && !tP.Any(t => t.TareaID == ID));
            tR.Add(tP[ID]);
            tP.RemoveAt(ID);
            Console.WriteLine("Deseas seguir Moviendo Tareas? (Y/N)");
            bandera = Console.ReadLine();
            if (bandera == "N")
            {
                continuar = false;
            }
        }
        
    }
    static void MostrarTareas(List <Tarea> t)
    {
        foreach (Tarea tarea in t)
        {
            Console.WriteLine("\nID: " + tarea.TareaID);
            Console.WriteLine("Tarea: " + tarea.Descripcion);
            Console.WriteLine("Plazo de entrega: \n" + tarea.Duracion);
        }
    }
    static void BuscarTarea(List <Tarea> t)
    {
        string busqueda; 
        Console.WriteLine("Escriba la tarea que busca");
        busqueda = Console.ReadLine();
        if (t.Any(p => p.Descripcion == busqueda))
        {
            Tarea tarea = t.First(p => p.Descripcion == busqueda);
            Console.WriteLine("\nID: " + tarea.TareaID);
            Console.WriteLine("Tarea: " + tarea.Descripcion);
            Console.WriteLine("Plazo de entrega: \n" + tarea.Duracion);
        } else
        {
            Console.WriteLine("La tarea buscada no existe");
        }
    }
    static void Operar(List <Tarea> tP, List<Tarea> tR)
    {
        bool continuar = true;
        int op;
        string entrada, bandera;
        Console.WriteLine("Bienvenido al Centro de Tareas!\n\n");
        while (continuar)
        {
            Console.WriteLine("Selecciona que operacion deseas realizar:");
            Console.WriteLine("1.Mover Tareas");
            Console.WriteLine("2.Buscar Tarea");
            Console.WriteLine("3.Ver Tareas Pendientes");
            Console.WriteLine("4.Ver Tareas Realizadas");
            do
            {
                Console.WriteLine("Selecciona que operacion deseas realizar:");
                entrada = Console.ReadLine();
                
            } while (int.TryParse(entrada, out op) && op < 0 && op > 5);
            

            switch (op)
            {
                case 1:
                    MoverTareas(tP, tR);
                    break;
                case 2:
                    BuscarTarea(tP);
                    break;
                case 3:
                    MostrarTareas(tP);
                    break;
                case 4:
                    MostrarTareas(tR);
                    break;
            }
            Console.WriteLine("Deseas seguir Operando? (Y/N)");
            bandera = Console.ReadLine();
            if (bandera == "N")
            {
                continuar = false;
            }

        }
    }
}