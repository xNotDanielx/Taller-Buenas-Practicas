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
                        repositorioRegimenContributivo.GuardarPaciente(Paciente);
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
                        pacientesContributivos.Remove(repositorioRegimenContributivo.BuscarPorNumeroLiquidacion(numeroLiquidacion));
                        repositorioRegimenContributivo.EliminarPaciente(pacientesContributivos);
                        return $"El paciente con identificación {numeroLiquidacion} ha sido eliminado correctamente";
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
                        Console.WriteLine($"El paciente con identificación {numeroLiquidacion} no ha sido registrado como contributivo");
                    }
                    else
                    {
                        for (int i = 0; i <= pacientesContributivos.Count(); i++)
                        {
                            if (numeroLiquidacion.Equals(pacientesContributivos[i].NumeroLiquidacion))
                            {
                                pacientesContributivos[i].ValorServicioPrestado = NuevoValorServicioPrestado();
                                pacientesContributivos[i].ValidarCuotaModeradora();
                                repositorioRegimenContributivo.EliminarPaciente(pacientesContributivos);
                                Console.WriteLine("Valor de servicio prestado modificado correctamente");
                            }
                        }
                    }
                } else
                {
                    Console.WriteLine("No existen pacientes contributivos en este momento para modificar");
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
            Console.WriteLine(" MODIFCAR PACIENTE CONTRIBUTIVO \n");

            float NuevoValor;
            do
            {
                Console.WriteLine("Ingrese el nuevo valor del servicio: ");
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
