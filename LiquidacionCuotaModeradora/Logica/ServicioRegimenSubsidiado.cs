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
                        repositorioRegimenSubsidiado.GuardarPaciente(Paciente);
                        return $"Se han guardado correctamente los datos del paciente con identificación: {Paciente.IdPaciente} ";
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
                        pacientesSubsidiados.Remove(repositorioRegimenSubsidiado.BuscarPorNumeroLiquidacion(numeroLiquidacion));
                        repositorioRegimenSubsidiado.EliminarPaciente(pacientesSubsidiados);
                        return $"El paciente con identificación {numeroLiquidacion} ha sido eliminado correctamente";
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
                        Console.WriteLine($"El paciente con identificación {numeroLiquidacion} no ha sido registrado como subsidiado");
                    }
                    else
                    {
                        for (int i = 0; i <= pacientesSubsidiados.Count(); i++)
                        {
                            if (numeroLiquidacion.Equals(pacientesSubsidiados[i].NumeroLiquidacion))
                            {
                                pacientesSubsidiados[i].ValorServicioPrestado = NuevoValorServicioPrestado();
                                pacientesSubsidiados[i].ValidarCuotaModeradora();
                                repositorioRegimenSubsidiado.EliminarPaciente(pacientesSubsidiados);
                                Console.WriteLine("Valor de servicio prestado modificado correctamente");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No existen pacientes subsidiados en este momento para modificar");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error de la aplicación: {e.Message}");
            }
        }

        private float NuevoValorServicioPrestado()
        {
            Console.Clear();
            Console.WriteLine(" MODIFCAR PACIENTE SUBSIDIADO \n");

            float NuevoValor;
            do
            {
                Console.WriteLine("Ingrese el nuevo valor del servicio: ");
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
    }
}
