using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

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

        public void EliminarPaciente(List<RegimenContributivo> Pacientes)
        {
            throw new NotImplementedException();
        }

        public List<RegimenContributivo> GetAll()
        {
            throw new NotImplementedException();
        }                
    }
}
