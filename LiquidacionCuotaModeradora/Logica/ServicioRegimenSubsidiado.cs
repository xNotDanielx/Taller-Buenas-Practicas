using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Logica
{
    public class ServicioRegimenSubsidiado : IPaciente<RegimenSubsidiado>
    {

        RepositorioRegimenSubsidiado repositorioRegimenSubsidiado = new RepositorioRegimenSubsidiado();
        RepositorioRegimenContributivo repositorioRegimenContributivo = new RepositorioRegimenContributivo();
        List<RegimenSubsidiado> pacientesSubsidiados;

        public ServicioRegimenSubsidiado()
        {
            refresh();
        }

        public string GuardarPaciente(RegimenSubsidiado Paciente)
        {
            try
            {
                if (Paciente != null)
                {
                    // Valido que el paciente no exista en ninguno de los DOS archivos
                    if (repositorioRegimenSubsidiado.BuscarPorId(Paciente.IdPaciente) == null && repositorioRegimenContributivo.BuscarPorId(Paciente.IdPaciente) == null)
                    {
                        if (repositorioRegimenSubsidiado.BuscarPorNumeroLiquidacion(Paciente.NumeroLiquidacion) == null && repositorioRegimenContributivo.BuscarPorNumeroLiquidacion(Paciente.NumeroLiquidacion) == null)
                        {
                            repositorioRegimenSubsidiado.GuardarPaciente(Paciente);
                            return $"Se han guardado correctamente los datos del paciente con identificación: {Paciente.IdPaciente} ";
                        }
                        else
                        {
                            return $"No se puede registrar. El numero de liquidación {Paciente.NumeroLiquidacion} ya se encuentra registrada";
                        }
                    }
                    else
                    {
                        return $"No se puede registrar. La identificación {Paciente.IdPaciente} ya se encuentra registrada";
                    }
                }
                else
                {
                    return "El paciente no puede ser nulo";
                }
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message}";
            }
        }

        public void refresh()
        {
            try
            {
                pacientesSubsidiados = repositorioRegimenSubsidiado.GetAll();
            }
            catch (Exception)
            {

            }
        }

        public string EliminarPaciente(string numeroLiquidacion)
        {
            try
            {
                if (pacientesSubsidiados != null)
                {
                    if (repositorioRegimenSubsidiado.BuscarPorNumeroLiquidacion(numeroLiquidacion) == null)
                    {
                        return $"El paciente con identificación {numeroLiquidacion} no ha sido registrado como subsidiado";
                    }
                    else
                    {
                        pacientesSubsidiados.RemoveAll(paciente => paciente.NumeroLiquidacion == numeroLiquidacion);
                        repositorioRegimenSubsidiado.ActualizarLista(pacientesSubsidiados);
                        return $"El paciente con identificación {numeroLiquidacion} ha sido eliminado correctamente de los subsidiados";
                    }
                }
                else
                {
                    return "No existen pacientes subsidiados en este momento para eliminar";
                }
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message}";
            }
        }

        public void ModificarPaciente(string numeroLiquidacion)
        {
            try
            {
                if (pacientesSubsidiados != null)
                {
                    if (repositorioRegimenSubsidiado.BuscarPorNumeroLiquidacion(numeroLiquidacion) == null)
                    {
                        Console.SetCursorPosition(10, 8); Console.WriteLine($"El paciente con identificación {numeroLiquidacion} no ha sido registrado como subsidiado");
                        Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse cualquier tecla para volver al menú");
                        Console.ReadKey();
                    }
                    else
                    {
                        for (int i = 0; i < pacientesSubsidiados.Count(); i++)
                        {
                            if (numeroLiquidacion.Equals(pacientesSubsidiados[i].NumeroLiquidacion))
                            {
                                pacientesSubsidiados[i].ValorServicioPrestado = NuevoValorServicioPrestado();
                                pacientesSubsidiados[i].ValidarCuotaModeradora();
                                repositorioRegimenSubsidiado.ActualizarLista(pacientesSubsidiados);
                                
                                Console.SetCursorPosition(10, 10); Console.WriteLine("Valor de servicio prestado modificado correctamente");
                                Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse cualquier tecla para volver al menú");
                                Console.ReadKey();
                            }
                        }
                    }
                }
                else
                {
                    Console.SetCursorPosition(10, 8); Console.WriteLine("No existen pacientes subsidiados en este momento para modificar");
                    Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse cualquier tecla para volver al menú");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.SetCursorPosition(10, 10); Console.WriteLine($"Error de la aplicación: {e.Message}");
                Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse cualquier tecla para volver al menú");
                Console.ReadKey();
            }
        }

        private float NuevoValorServicioPrestado()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 5); Console.WriteLine(" *** MODIFCAR PACIENTE SUBSIDIADO *** ");

            float NuevoValor;
            do
            {
                Console.SetCursorPosition(10, 7); Console.WriteLine("Ingrese el nuevo valor del servicio: ");
            } while (!float.TryParse(Console.ReadLine().Trim(), out NuevoValor) || NuevoValor < 0);

            return NuevoValor;
        }

        public List<RegimenSubsidiado> GetAll()
        {
            refresh();

            if (pacientesSubsidiados == null)
            {
                return null;
            }
            return pacientesSubsidiados;
        }

        //public RegimenSubsidiado BuscarPorTipoAfiliacion()
        //{
        //    refresh();

        //    if (pacientesSubsidiados == null)
        //    {
        //        return null;
        //    }
        //    foreach (var item in pacientesSubsidiados)
        //    {
        //        if (item.TipoAfiliacion == "Subsidiado")
        //        {
        //            return item;
        //        }
        //    }
        //    return null;
        //}
    }
}
