using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioRegimenContributivo : IRegimen<RegimenContributivo>
    {
        string ruta = "Pacientes_Regimen_Contributivo.txt";
        public void GuardarPaciente(RegimenContributivo paciente)
        {
            StreamWriter writer = new StreamWriter(ruta, true);
            writer.WriteLine(paciente.ToString());
            writer.Close();
        }

        public RegimenContributivo BuscarPorId(string identificacion)
        {
            List<RegimenContributivo> pacientesContributivos = GetAll();

            foreach (var item in pacientesContributivos)
            {
                if (item.IdPaciente == identificacion)
                {
                    return item;
                }
            }
            return null;
        }

        public RegimenContributivo Mapper(string linea)
        {
            var Paciente = new RegimenContributivo();
            string[] datos = linea.Split(';');
            Paciente.NumeroLiquidacion = datos[0];
            Paciente.IdPaciente = datos[1];
            Paciente.TipoAfiliacion = datos[2];
            Paciente.SalarioDevengadoPaciente = float.Parse(datos[3]);
            Paciente.CuotaModeradora = float.Parse(datos[4]);
            Paciente.ValorServicioPrestado = float.Parse(datos[5]);
            return Paciente;
        }

        public List<RegimenContributivo> GetAll()
        {
            try
            {
                List<RegimenContributivo> Pacientes = new List<RegimenContributivo>();
                StreamReader reader = new StreamReader(ruta);
                while (!reader.EndOfStream)
                {
                    Pacientes.Add(Mapper(reader.ReadLine()));
                }
                reader.Close();
                return Pacientes;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public void EliminarPaciente(List<RegimenContributivo> Pacientes)
        {
            string rutatemp = "Temporal.txt";
            try
            {
                StreamWriter sw = new StreamWriter(rutatemp, true);
                foreach (var item in Pacientes)
                {
                    sw.WriteLine(item.ToString());
                }
                sw.Close();
                File.Delete(ruta);
                File.Move(rutatemp, ruta);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
