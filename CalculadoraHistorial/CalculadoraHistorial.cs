namespace EspacioCalculadora;

using System;
using System.Collections.Generic;
using System.Linq;

public enum TipoOperacion{
    Suma,
    Resta,
    Multiplicacion,
    Division,
    Limpiar // Representa la acción de borrar el resultado actual o el historial
}

public class Operacion
{

    private double resultadoAnterior; // Almacena el resultado previo al cálculo actual
    private double nuevoValor; //El valor con el que se opera sobre el resultadoAnterior
    private TipoOperacion operacion;// El tipo de operación realizada
    public double Resultado{ /* Lógica para calcular o devolver el resultado */
        get
        {
            switch (this.operacion)
            {
                case TipoOperacion.Suma:
                    return resultadoAnterior + nuevoValor;
                case TipoOperacion.Resta:
                    return resultadoAnterior - nuevoValor;
                case TipoOperacion.Multiplicacion:
                    return resultadoAnterior * nuevoValor;
                case TipoOperacion.Division:
                    if(nuevoValor != 0)
                    {
                        return resultadoAnterior / nuevoValor;
                    }
                    throw new DivideByZeroException("No se puede dividir por cero.");
                case TipoOperacion.Limpiar:
                    return 0;
                default:
                    return resultadoAnterior;
            }
        }
    }
    public double ResultadoAnterior
    {
        get {return resultadoAnterior;}
    }
// Propiedad pública para acceder al nuevo valor utilizado en la operación
    public double NuevoValor
    {
        get {return nuevoValor;}
    }
// Constructor u otros métodos necesarios para inicializar y gestionar la operación
// ...
    public TipoOperacion Tipo
    {
        get {return operacion;}
    }

    public void Inicializar(double resultadoAnterior, double nuevo, TipoOperacion operacion)
    {
        this.resultadoAnterior = resultadoAnterior;
        this.nuevoValor = nuevo;
        this.operacion = operacion;
    }
}
public class Calculadora
{
    public double dato = 0;

    public double ResultadoAnterior
    {
        get
        {
            if(historial.Count == 0)
            {
                return 0;
            }
            else
            {
                return historial.Last().Resultado;
            }
        }
    }

    public List <Operacion> historial = new List<Operacion>();
    public void Operar(double termino, TipoOperacion tipo)
    {
        if (termino == 0 && tipo == TipoOperacion.Division)
        {
            Console.WriteLine("\n Error: No se puede dividir por 0. Cancelando Operacion... \n");
            return;
        }
        Operacion nuevaOp = new();
        nuevaOp.Inicializar(this.ResultadoAnterior, termino, tipo);
        historial.Add(nuevaOp);
    }

// Método para mostrar el historial por consola
    public void MostrarHistorial()
    {
        Console.WriteLine("\n--- HISTORIAL DE CÁLCULOS ---");
        if (historial.Count == 0)
        {
            Console.WriteLine("No hay operaciones registradas.");
            return;
        }

        int i = 1;
        foreach (var op in historial)
        {
            string simbolo = op.Tipo switch
            {
                TipoOperacion.Suma => "+",
                TipoOperacion.Resta => "-",
                TipoOperacion.Multiplicacion => "*",
                TipoOperacion.Division => "/",
                TipoOperacion.Limpiar => "L",
                _ => throw new NotImplementedException(),
            };

            if (op.Tipo == TipoOperacion.Limpiar)
            {
                Console.WriteLine($"[{i}] Se limpió la calculadora. Resultado = 0");
            }
            else
            {
                Console.WriteLine($"[{i}] {op.ResultadoAnterior} {simbolo} {op.NuevoValor} = {op.Resultado}");
            }
            i++;
        }
        Console.WriteLine("-----------------------------\n");
    }

    public void Menu()
    {
        
        Console.WriteLine("Seleccione la operacion que desea Realizar ingresando el numero correspondiente:");
        Console.WriteLine("1.Sumar");
        Console.WriteLine("2.Restar");
        Console.WriteLine("3.Multiplicar");
        Console.WriteLine("4.Dividir");
        Console.WriteLine("5.Limpiar");
        Console.WriteLine("6.Mostrar Historial");
    }
}

