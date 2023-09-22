using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public interface IRegimen<T>
    {
        void GuardarPaciente(T paciente);
        T Mapper(string linea);
        List<T> GetAll();
        void EliminarPaciente(List<T> Pacientes);        
    }
}
