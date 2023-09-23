using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface IPaciente<T>
    {
        string GuardarPaciente(T Paciente);
        void refresh();
        List<T> GetAll();
        void EliminarPaciente(List<T> Pacientes);
    }
}
