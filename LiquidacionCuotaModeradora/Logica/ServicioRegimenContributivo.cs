using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Security.Cryptography;

namespace Logica
{
    public class ServicioRegimenContributivo : IPaciente<RegimenContributivo>
    {

        RepositorioRegimenContributivo repositorioRegimenContributivo = new RepositorioRegimenContributivo();
        RepositorioRegimenSubsidiado repositorioRegimenSubsidiado = new RepositorioRegimenSubsidiado();
        List<RegimenContributivo> pacientesContributivos;

        public ServicioRegimenContributivo()
        {
            refresh();
        }

        public string GuardarPaciente(RegimenContributivo Paciente)
        {
            try
            {
                if (Paciente != null)
                {
                    // Valido que el paciente no exista en ninguno de los DOS archivos
                    if (repositorioRegimenContributivo.BuscarPorId(Paciente.IdPaciente) == null && repositorioRegimenSubsidiado.BuscarPorId(Paciente.IdPaciente) == null)
                    {
                        if (repositorioRegimenContributivo.BuscarPorNumeroLiquidacion(Paciente.NumeroLiquidacion) == null && repositorioRegimenSubsidiado.BuscarPorNumeroLiquidacion(Paciente.NumeroLiquidacion) == null)
                        {
                            repositorioRegimenContributivo.GuardarPaciente(Paciente);
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
                pacientesContributivos = repositorioRegimenContributivo.GetAll();
            }
            catch (Exception)
            {

            }
        }

        public string EliminarPaciente(string numeroLiquidacion)
        {
            try
            {
                if (pacientesContributivos != null)
                {
                    if (repositorioRegimenContributivo.BuscarPorNumeroLiquidacion(numeroLiquidacion) == null)
                    {
                        return $"El paciente con identificación {numeroLiquidacion} no ha sido registrado como contributivo";
                    }
                    else
                    {
                        pacientesContributivos.RemoveAll(paciente => paciente.NumeroLiquidacion == numeroLiquidacion);
                        repositorioRegimenContributivo.EliminarPaciente(pacientesContributivos);
                        return $"El paciente con identificación {numeroLiquidacion} ha sido eliminado correctamente de los contributivos";
                    }
                }
                else
                {
                    return "No existen pacientes contributivos en este momento para eliminar";
                }
            } catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message}";
            }
        }

        public void ModificarPaciente(string numeroLiquidacion)
        {
            try
            {
                if (pacientesContributivos != null)
                {
                    if (repositorioRegimenContributivo.BuscarPorNumeroLiquidacion(numeroLiquidacion) == null)
                    {
                        Console.SetCursorPosition(10, 8); Console.WriteLine($"El paciente con identificación {numeroLiquidacion} no ha sido registrado como contributivo");
                        Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse cualquier tecla para volver al menú");
                        Console.ReadKey();
                    }
                    else
                    {
                        for (int i = 0; i < pacientesContributivos.Count(); i++)
                        {
                            if (numeroLiquidacion.Equals(pacientesContributivos[i].NumeroLiquidacion))
                            {
                                pacientesContributivos[i].ValorServicioPrestado = NuevoValorServicioPrestado();
                                pacientesContributivos[i].ValidarCuotaModeradora();
                                repositorioRegimenContributivo.EliminarPaciente(pacientesContributivos);
                                Console.SetCursorPosition(10, 10); Console.WriteLine("Valor de servicio prestado modificado correctamente");
                                Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse cualquier tecla para volver al menú");
                                Console.ReadKey();
                            }
                        }
                    }
                } else
                {
                    Console.SetCursorPosition(10, 8); Console.WriteLine("No existen pacientes contributivos en este momento para modificar");
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
            Console.SetCursorPosition(10, 5); Console.WriteLine(" *** MODIFCAR PACIENTE CONTRIBUTIVO *** ");

            float NuevoValor;
            do
            {
                Console.SetCursorPosition(10, 7); Console.WriteLine("Ingrese el nuevo valor del servicio: ");
            } while (!float.TryParse(Console.ReadLine().Trim(), out NuevoValor) || NuevoValor < 0);

            return NuevoValor;
        }

        public List<RegimenContributivo> GetAll()
        {
            refresh();

            if (pacientesContributivos == null)
            {
                return null;
            }
            return pacientesContributivos;
        }        
    }
}
