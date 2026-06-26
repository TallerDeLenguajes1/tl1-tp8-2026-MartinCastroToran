using EspacioCalculadora;


internal class Program
{
    private static void Main()
    {
        bool continuar = true;
        string entradaOp, entradaNum, entradaBandera;
        int operacion = 0;
        double num = 0;
        Console.WriteLine("\nBienvenido a la Calculadora 2.0 de Taller!\n");
        Calculadora calc = new Calculadora();
        while (continuar)
        {
            do
            {
                calc.Menu();
                entradaOp = Console.ReadLine();
            } while (!int.TryParse(entradaOp, out operacion) || operacion > 7 || operacion < 0);
            if (operacion == 6)
            {
                Console.WriteLine("Mostrando Historial...\n");
            }
            else if (operacion == 5)
            {
                Console.WriteLine("Calculadora reiniciada!\n");
            }
            else{
                do{
                    Console.WriteLine("Ingrese el termino a operar");
                    entradaNum = Console.ReadLine();
                } while (!double.TryParse(entradaNum, out num));
            }
            
            
            switch (operacion)
            {
                case 1:
                    calc.Operar(num, TipoOperacion.Suma);
                    break;
                case 2:
                    calc.Operar(num, TipoOperacion.Resta);
                    break;
                case 3:
                    calc.Operar(num, TipoOperacion.Multiplicacion);
                    break;
                case 4:
                    calc.Operar(num, TipoOperacion.Division);
                    break;
                case 5:
                    calc.Operar(num, TipoOperacion.Limpiar);
                    break;
                case 6:
                    calc.MostrarHistorial();
                    break;
            }
            Console.WriteLine("\nResultado: " + calc.ResultadoAnterior);
            Console.WriteLine("\n\nDesea Continuar Operando? (Y/N):");
            entradaBandera = Console.ReadLine();
            if (entradaBandera == "N")
            {
                Console.WriteLine("Resultado Final: " + calc.ResultadoAnterior);
                continuar = false;
            }
        }
    }   
}
