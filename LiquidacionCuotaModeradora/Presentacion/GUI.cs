using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Presentacion
{
    public class GUI
    {
        public void Menu()
        {
            int opcionSeleccionada = 0;

            do
            {
                try
                {
                    Console.Clear();

                    switch(opcionSeleccionada)
                    {
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                        case 6:
                            Console.SetCursorPosition(10, 23); Console.Write("TERMINANDO PROGRAMA...");
                            Thread.Sleep(1500);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("¡ERROR! La opción digitada no existe");
                            Console.WriteLine("Pulse cualquier tecla para volver al menú");
                            Console.ReadKey();
                            break;
                    }
                } catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("¡ERROR! Caracter no válido");
                    Console.WriteLine("Pulse cualquier tecla para volver al menú");
                    Console.ReadKey();
                }
            } while (opcionSeleccionada != 6);
        }


    }
}
