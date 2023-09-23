using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Presentacion
{
    public class VistasGUI
    {
        public void MenuVistas()
        {
            int opcionSeleccionada = 0;

            do
            {
                Console.Clear();
                Console.SetCursorPosition(10, 5); Console.WriteLine("Bienvenido al sistema de Vistas de la aplicación");
                Console.SetCursorPosition(10, 7); Console.WriteLine("1. Ver total de cuotas moderadoras liquidadas por tipo de afiliación");
                try
                {
                    Console.Clear();

                    switch (opcionSeleccionada)
                    {
                        case 1:
                            TotalizarCuotasModeradorasLiquidadasPorTipoDeAfiliacion();
                            break;
                        case 2:
                            //VistaCuotasModeradorasLiquidadasPorTipoAfiliacion();
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
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("¡ERROR! Caracter no válido");
                    Console.WriteLine("Pulse cualquier tecla para volver al menú");
                    Console.ReadKey();
                }
            } while (opcionSeleccionada != 6);
        }

        public void VistaCuotasModeradorasLiquidadasPorTipoAfiliacion()
        {
            int OpcionSeleccionada = 0;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(10, 5); Console.WriteLine("1- Regimen Contributivo");
                Console.SetCursorPosition(10, 7); Console.WriteLine("2- Regimen Subsidiado");
                Console.SetCursorPosition(10, 9); Console.WriteLine("Opción: "); OpcionSeleccionada = int.Parse(Console.ReadLine());
                try
                {
                    switch (OpcionSeleccionada)
                    {
                        case 1:
                            VerCuotaRegimenContributivo();
                            break;
                        case 2:
                            //VerCuotaRegimenSubsidiado();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("¡ERROR! La opción digitada no existe");
                            Console.WriteLine("Pulse cualquier tecla para volver al menú");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("¡ERROR! Caracter no válido");
                    Console.WriteLine("Pulse cualquier tecla para volver al menú");
                    Console.ReadKey();
                }
            } while (OpcionSeleccionada != 0);
        }

        public void TotalizarCuotasModeradorasLiquidadasPorTipoDeAfiliacion()
        {
            int OpcionSeleccionada = 0;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(10, 5); Console.WriteLine("1- Regimen Contributivo");
                Console.SetCursorPosition(10, 7); Console.WriteLine("2- Regimen Subsidiado");
                Console.SetCursorPosition(10, 9); Console.WriteLine("Opción: "); OpcionSeleccionada = int.Parse(Console.ReadLine());
                try
                {
                    switch (OpcionSeleccionada)
                    {
                        case 1:
                            TotalRegimenContributivo();
                            break;
                        case 2: 
                            TotalRegimenSubsidiado();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("¡ERROR! La opción digitada no existe");
                            Console.WriteLine("Pulse cualquier tecla para volver al menú");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("¡ERROR! Caracter no válido");
                    Console.WriteLine("Pulse cualquier tecla para volver al menú");
                    Console.ReadKey();
                }
            }while(OpcionSeleccionada != 0);
        }

        public void VerCuotaRegimenSubsidiado()
        {
            ServicioRegimenSubsidiado servicioRegimenSubsidiado = new ServicioRegimenSubsidiado();
            Console.Clear();
            int i = 7;
            if (servicioRegimenSubsidiado.GetAll() == null)
            {
                Console.SetCursorPosition(10, 10); Console.WriteLine("No hay pacientes en el regimen subsidiado");
                Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(10, 5); Console.WriteLine("Cuotas Moderadoras Regimen Subsidiado");
                Console.SetCursorPosition(10, 6); Console.WriteLine("|Numero Liquidacion|----ID----|Tipo de afiliacion|Cuota Moderadora|");
                Console.SetCursorPosition(10, 7); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 8); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 9); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 10); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 11); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 12); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 13); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 14); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 15); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 16); Console.WriteLine("|                  |          |                  |                |");

                foreach (var item in servicioRegimenSubsidiado.GetAll())
                {
                    Console.SetCursorPosition(2, i); Console.Write(item.NumeroLiquidacion);
                    Console.SetCursorPosition(20, i); Console.Write(item.IdPaciente);
                    Console.SetCursorPosition(35, i); Console.Write(item.TipoAfiliacion);
                    Console.SetCursorPosition(55, i); Console.Write(item.CuotaModeradora);
                    i++;
                }
                Console.SetCursorPosition(10, i + 2); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }
        }

        public void VerCuotaRegimenContributivo()
        {
            ServicioRegimenContributivo servicioRegimenContributivo = new ServicioRegimenContributivo();
            Console.Clear();
            int i = 7;
            if(servicioRegimenContributivo.GetAll() == null)
            {
                Console.SetCursorPosition(10, 10); Console.WriteLine("No hay pacientes en el regimen contributivo");
                Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(10, 5); Console.WriteLine("Cuotas Moderadoras Regimen Contributivo");
                Console.SetCursorPosition(10, 6); Console.WriteLine("|Numero Liquidacion|----ID----|Tipo de afiliacion|Cuota Moderadora|");
                Console.SetCursorPosition(10, 7); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 8); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 9); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 10); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 11); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 12); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 13); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 14); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 15); Console.WriteLine("|                  |          |                  |                |");
                Console.SetCursorPosition(10, 16); Console.WriteLine("|                  |          |                  |                |");

                foreach (var item in servicioRegimenContributivo.GetAll())
                {
                    Console.SetCursorPosition(2, i); Console.Write(item.NumeroLiquidacion);
                    Console.SetCursorPosition(20, i); Console.Write(item.IdPaciente);
                    Console.SetCursorPosition(35, i); Console.Write(item.TipoAfiliacion);
                    Console.SetCursorPosition(55, i); Console.Write(item.CuotaModeradora);
                    i++;
                }
                Console.SetCursorPosition(10, i+2); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }
        }

        public void TotalRegimenContributivo()
        {
            ServicioRegimenContributivo servicioRegimenContributivo = new ServicioRegimenContributivo();
            Console.Clear();
            Console.SetCursorPosition(10, 5); Console.WriteLine($"Se han realizado {servicioRegimenContributivo.GetAll().Count()} liquidaciones hasta el momento");
        }

        public void TotalRegimenSubsidiado()
        {
            ServicioRegimenSubsidiado servicioRegimenSubsidiado = new ServicioRegimenSubsidiado();
            Console.Clear();
            Console.SetCursorPosition(10, 5); Console.WriteLine($"Se han realizado {servicioRegimenSubsidiado.GetAll().Count()} liquidaciones hasta el momento");
        }
    }
}
