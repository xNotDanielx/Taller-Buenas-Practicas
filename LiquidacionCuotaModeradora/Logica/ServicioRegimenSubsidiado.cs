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

        public void EliminarPaciente(List<RegimenSubsidiado> Pacientes)
        {
            throw new NotImplementedException();
        }

        public List<RegimenSubsidiado> GetAll()
        {
            throw new NotImplementedException();
        }                
    }
}
