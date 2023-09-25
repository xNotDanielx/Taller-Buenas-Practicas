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
        public void MenuFiltros()
        {
            int opcionSeleccionada;

            do
            {
                Console.Clear();
                Console.SetCursorPosition(10, 5); Console.WriteLine("Bienvenido al sistema de Vistas de la aplicación");
                Console.SetCursorPosition(10, 7); Console.WriteLine("1. Ver total de cuotas moderadoras liquidadas por tipo de afiliación");
                Console.SetCursorPosition(10, 8); Console.WriteLine("2. Ver cuotas moderadoras liquidadas por tipo de afiliación");
                Console.SetCursorPosition(10, 9); Console.WriteLine("0. Volver");
                Console.SetCursorPosition(10, 9); Console.WriteLine("Opcion: "); opcionSeleccionada = int.Parse(Console.ReadLine());
                try
                {
                    Console.Clear();

                    switch (opcionSeleccionada)
                    {
                        case 1:
                            TotalizarCuotasModeradorasLiquidadasPorTipoDeAfiliacion();
                            break;
                        case 2:
                            VistaTotalCuotasCuotasModeradoras();
                            break;
                        case 3:

                            break;
                        case 4:

                            break;

                        case 0:
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
            } while (opcionSeleccionada != 0);
        }
        
        public void TotalizarCuotasModeradorasLiquidadasPorTipoDeAfiliacion()
        {
            int OpcionSeleccionada;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(10, 5); Console.WriteLine("1. Regimen Contributivo");
                Console.SetCursorPosition(10, 7); Console.WriteLine("2. Regimen Subsidiado");
                Console.SetCursorPosition(10, 9); Console.WriteLine("0. Volver");
                Console.SetCursorPosition(10, 9); Console.Write("Opción: "); OpcionSeleccionada = int.Parse(Console.ReadLine());
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

                        case 0:
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

        public void TotalRegimenContributivo()
        {
            ServicioRegimenContributivo servicioRegimenContributivo = new ServicioRegimenContributivo();
            Console.Clear();
            if (servicioRegimenContributivo.GetAll() == null)
            {
                Console.SetCursorPosition(10, 5); Console.WriteLine("No hay pacientes en el regimen subsidiado");
                Console.SetCursorPosition(10, 7); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(10, 5); Console.WriteLine($"Se han realizado {servicioRegimenContributivo.GetAll().Count()} liquidaciones hasta el momento");
                Console.SetCursorPosition(10, 7); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }
        }

        public void TotalRegimenSubsidiado()
        {
            ServicioRegimenSubsidiado servicioRegimenSubsidiado = new ServicioRegimenSubsidiado();
            Console.Clear();
            if (servicioRegimenSubsidiado.GetAll() == null)
            {
                Console.SetCursorPosition(10, 5); Console.WriteLine("No hay pacientes en el regimen subsidiado");
                Console.SetCursorPosition(10, 7); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(10, 5); Console.WriteLine($"Se han realizado {servicioRegimenSubsidiado.GetAll().Count()} liquidaciones hasta el momento");
                Console.SetCursorPosition(10, 7); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }            
        }
        
        public void VistaTotalCuotasCuotasModeradoras()
        {
            ServicioRegimenContributivo servicioRegimenContributivo = new ServicioRegimenContributivo();
            ServicioRegimenSubsidiado servicioRegimenSubsidiado = new ServicioRegimenSubsidiado();
            Console.Clear();
            if ((TotalCuotasRegimenContributivo() == 0) && (TotalCuotasRegimenSubsidiado() == 0))
            {
                Console.SetCursorPosition(10, 5); Console.WriteLine("No hay cuotas moderadoras liquidadas hasta el momento");
                Console.SetCursorPosition(10, 7); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(10, 5); Console.WriteLine($"El total de cuotas moderadoras liquidadas hasta el momento es de: {TotalCuotasRegimenContributivo() + TotalCuotasRegimenSubsidiado()}$");
                Console.SetCursorPosition(10, 7); Console.WriteLine($"{TotalCuotasRegimenContributivo()}$ en el régimen contributivo");
                Console.SetCursorPosition(10, 8); Console.WriteLine($"{TotalCuotasRegimenSubsidiado()}$ en el régimen subsidiado");
                Console.SetCursorPosition(10, 10); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }
        }

        public float TotalCuotasRegimenContributivo()
        {
            ServicioRegimenContributivo servicioRegimenContributivo = new ServicioRegimenContributivo();
            float Total;
            if(servicioRegimenContributivo.GetAll() == null)
            {
                Total = 0f;
                return Total;
            }
            else
            {
                Total = servicioRegimenContributivo.GetAll().Sum(x => x.CuotaModeradora);
                return Total;
            }
        }

        public float TotalCuotasRegimenSubsidiado()
        {
            ServicioRegimenSubsidiado servicioRegimenSubsidiado = new ServicioRegimenSubsidiado();
            float Total;
            if (servicioRegimenSubsidiado.GetAll() == null)
            {
                Total = 0f;
                return Total;
            }
            else
            {
                Total = servicioRegimenSubsidiado.GetAll().Sum(x => x.CuotaModeradora);
                return Total;
            }
        }
    }
}
