namespace EspacioTarea;

using System.Security.Cryptography;



public class Tarea
{
    private int tareaID;
    private string descripcion;
    private int duracion;
    public int TareaID {get; set;}
    public string Descripcion {get; set;}
    public int Duracion{
        get {return duracion;}
        set
        {
            if (value < 10 || value > 100)
            {
                throw new ArgumentOutOfRangeException("La duracion debe estar entre 10 y 100 Dias.");
            }
            else
            {
                duracion = value;
            }
        }
    }
    
}