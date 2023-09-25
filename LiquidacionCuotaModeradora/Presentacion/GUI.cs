using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entidades;

namespace Presentacion
{
    public class GUI
    {
        VistasGUI vistasGUI = new VistasGUI();
        public void Menu()
        {            
            int opcionSeleccionada = 0;

            do
            {
                try
                {
                    Console.Clear();
                    Console.SetCursorPosition(10, 5); Console.WriteLine(" *** IPS MAS SALUD Y VIDA *** ");
                    Console.SetCursorPosition(10, 7); Console.WriteLine("1. Registrar paciente ");
                    Console.SetCursorPosition(10, 8); Console.WriteLine("2. Consultar pacientes ");
                    Console.SetCursorPosition(10, 9); Console.WriteLine("3. Consultar con filtros ");
                    Console.SetCursorPosition(10, 10); Console.WriteLine("4. Eliminar Liquidación ");
                    Console.SetCursorPosition(10, 11); Console.WriteLine("5. Modificar Liquidación ");
                    Console.SetCursorPosition(10, 12); Console.WriteLine("6. Salir del programa ");
                    Console.SetCursorPosition(10, 13); Console.Write("Opcion: ");
                    opcionSeleccionada = int.Parse(Console.ReadLine());

                    switch (opcionSeleccionada)
                    {
                        case 1:
                            RegistrarPaciente();
                            break;
                        case 2:
                            VerTodasLasCuotasModeradoras();
                            break;
                        case 3:
                            vistasGUI.MenuFiltros();
                            break;
                        case 4:
                            EliminarLiquidacion();
                            break;
                        case 5:
                            ModificarLiquidacion();
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

        private void RegistrarPaciente()
        {
            string numeroLiquidacion;
            //var fechaLiquidacion;
            string idPaciente;
            string tipoAfiliacion;
            float salarioDevengadoPaciente;
            float valorServicioPrestado;

            Console.Clear();
            Console.SetCursorPosition(10, 5); Console.WriteLine("*** REGISTRAR PACIENTE ***");

            int validarNumeroEntero;
            do
            {
                Console.SetCursorPosition(10, 7); Console.Write("Numero de liquidación: ");
                numeroLiquidacion = Console.ReadLine().Trim();
            } while (!int.TryParse(numeroLiquidacion, out validarNumeroEntero) || validarNumeroEntero <= 0);

            //// Falta validar y agregar atributo a la clase paciente
            //Console.SetCursorPosition(10, 7); Console.Write("Fecha de liquidación: ");
            //fechaLiquidacion = Console.ReadLine();

            do
            {
                Console.SetCursorPosition(10, 8); Console.Write("Identificación del paciente: ");
                idPaciente = Console.ReadLine().Trim();
            } while (!int.TryParse(idPaciente, out validarNumeroEntero) || validarNumeroEntero <= 0);

            do
            {
                Console.SetCursorPosition(10, 9); Console.Write("Tipo de afiliación [1(Contributivo) / 2(Subsidiado)]: ");
                tipoAfiliacion = Console.ReadLine().Trim();
            } while (tipoAfiliacion != "1" && tipoAfiliacion != "2");

            do
            {
                Console.SetCursorPosition(10, 10); Console.Write("Salario devengado: ");
            } while (!float.TryParse(Console.ReadLine().Trim(), out salarioDevengadoPaciente) || salarioDevengadoPaciente <= 0);

            do
            {
                Console.SetCursorPosition(10, 11); Console.Write("Valor servicio prestado: ");
            } while (!float.TryParse(Console.ReadLine().Trim(), out valorServicioPrestado) || valorServicioPrestado <= 0);



            if (tipoAfiliacion.Equals("1"))
            {
                RegimenContributivo pacienteContributivo = new RegimenContributivo(numeroLiquidacion, idPaciente, "Contributivo", salarioDevengadoPaciente, valorServicioPrestado);
                pacienteContributivo.ValidarCuotaModeradora();

                ServicioRegimenContributivo servicioRegimenContributivo = new ServicioRegimenContributivo();

                Console.SetCursorPosition(10, 12); Console.WriteLine(servicioRegimenContributivo.GuardarPaciente(pacienteContributivo));
                Console.SetCursorPosition(10, 14); Console.WriteLine("Pulse cualquier tecla para volver al menú");
                Console.ReadKey();
            }
            else
            {
                RegimenSubsidiado pacienteSubsidiado = new RegimenSubsidiado(numeroLiquidacion, idPaciente, "Subsidiado", salarioDevengadoPaciente, valorServicioPrestado);
                pacienteSubsidiado.ValidarCuotaModeradora();

                ServicioRegimenSubsidiado servicioRegimenSubsidiado = new ServicioRegimenSubsidiado();

                Console.SetCursorPosition(10, 12); Console.WriteLine(servicioRegimenSubsidiado.GuardarPaciente(pacienteSubsidiado));
                Console.SetCursorPosition(10, 14); Console.WriteLine("Pulse cualquier tecla para volver al menú");
                Console.ReadKey();
            }
        }

        private void EliminarLiquidacion()
        {
            ServicioRegimenContributivo servicioRegimenContributivo = new ServicioRegimenContributivo();
            ServicioRegimenSubsidiado servicioRegimenSubsidiado = new ServicioRegimenSubsidiado();

            Console.Clear();
            Console.SetCursorPosition(10, 5); Console.WriteLine(" *** ELIMINAR LIQUIDACIÓN *** ");
            Console.SetCursorPosition(10, 6); Console.Write("Digite el número de liquidación que desea eliminar: ");
            string numeroLiquidacion = Console.ReadLine();

            Console.SetCursorPosition(10, 8); Console.WriteLine(servicioRegimenSubsidiado.EliminarPaciente(numeroLiquidacion));
            Console.SetCursorPosition(10, 9); Console.WriteLine(servicioRegimenContributivo.EliminarPaciente(numeroLiquidacion));

            Console.SetCursorPosition(10, 14); Console.WriteLine("Pulse cualquier tecla para volver al menú");
            Console.ReadKey();
        }

        private void ModificarLiquidacion()
        {
            ServicioRegimenContributivo servicioRegimenContributivo = new ServicioRegimenContributivo();
            ServicioRegimenSubsidiado servicioRegimenSubsidiado = new ServicioRegimenSubsidiado();

            Console.Clear();
            Console.SetCursorPosition(10, 5); Console.WriteLine(" *** MODIFICAR LIQUIDACIÓN *** ");
            Console.SetCursorPosition(10, 6); Console.Write("Digite el número de liquidación que desea modificar: ");
            string numeroLiquidacion = Console.ReadLine();

            servicioRegimenSubsidiado.ModificarPaciente(numeroLiquidacion);
            servicioRegimenContributivo.ModificarPaciente(numeroLiquidacion);

        }

        public void VerTodasLasCuotasModeradoras()
        {
            ServicioRegimenSubsidiado servicioRegimenSubsidiado = new ServicioRegimenSubsidiado();
            ServicioRegimenContributivo servicioRegimenContributivo = new ServicioRegimenContributivo();
            Console.Clear();
            int i = 3;
            if (servicioRegimenSubsidiado.GetAll() == null && servicioRegimenContributivo.GetAll() == null)
            {
                Console.SetCursorPosition(10, 10); Console.WriteLine("No hay pacientes Registrados");
                Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(5, 2); Console.WriteLine("Cuotas Moderadoras Regimen Subsidiado");
                Console.SetCursorPosition(5, 3); Console.WriteLine("|----ID----|Tipo de afiliacion|Salario Devengado|Valor Servicio|Tarifa|Tope Maximo|Cuota Moderadora|");
                Console.SetCursorPosition(5, 4); Console.WriteLine("|          |                  |                 |              |      |           |                |");
                Console.SetCursorPosition(5, 5); Console.WriteLine("|          |                  |                 |              |      |           |                |");
                Console.SetCursorPosition(5, 6); Console.WriteLine("|          |                  |                 |              |      |           |                |");
                Console.SetCursorPosition(5, 7); Console.WriteLine("|          |                  |                 |              |      |           |                |");
                Console.SetCursorPosition(5, 8); Console.WriteLine("|          |                  |                 |              |      |           |                |");
                if(servicioRegimenContributivo.GetAll() != null)
                {
                    foreach (var item in servicioRegimenContributivo.GetAll())
                    {
                        i++;
                        Console.SetCursorPosition(6, i); Console.Write(item.IdPaciente);
                        Console.SetCursorPosition(20, i); Console.Write(item.TipoAfiliacion);
                        Console.SetCursorPosition(38, i); Console.Write(item.SalarioDevengadoPaciente + "$");
                        Console.SetCursorPosition(59, i); Console.Write(item.ValorServicioPrestado + "$");
                        Console.SetCursorPosition(70, i); Console.Write((item.Tarifa*100) + "%");
                        Console.SetCursorPosition(80, i); Console.Write(item.TopeMaximo);
                        Console.SetCursorPosition(92, i); Console.Write(item.CuotaModeradora + "$");
                    }
                }

                if(servicioRegimenSubsidiado.GetAll() != null)
                {
                    foreach (var item in servicioRegimenSubsidiado.GetAll())
                    {
                        i++;
                        Console.SetCursorPosition(6, i); Console.Write(item.IdPaciente);
                        Console.SetCursorPosition(20, i); Console.Write(item.TipoAfiliacion);
                        Console.SetCursorPosition(38, i); Console.Write(item.SalarioDevengadoPaciente + "$");
                        Console.SetCursorPosition(59, i); Console.Write(item.ValorServicioPrestado + "$");
                        Console.SetCursorPosition(70, i); Console.Write((item.Tarifa * 100) + "%");
                        Console.SetCursorPosition(80, i); Console.Write(item.TopeMaximo);
                        Console.SetCursorPosition(92, i); Console.Write(item.CuotaModeradora + "$");
                    }
                }
                Console.SetCursorPosition(10, 30); Console.WriteLine("Pulse enter para volver..."); Console.ReadKey();
            }
        }       
    }
}
