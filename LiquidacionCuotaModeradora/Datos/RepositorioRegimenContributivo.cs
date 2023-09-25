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

            if (pacientesContributivos == null)
            {
                return null;
            }
            else
            {
                foreach (var item in pacientesContributivos)
                {
                    if (item.IdPaciente == identificacion)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public RegimenContributivo BuscarPorNumeroLiquidacion(string numeroLiquidacion)
        {
            List<RegimenContributivo> pacientesContributivos = GetAll();

            if (pacientesContributivos == null)
            {
                return null;
            }
            else
            {
                foreach (var item in pacientesContributivos)
                {
                    if (item.NumeroLiquidacion == numeroLiquidacion)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public RegimenContributivo BuscarPorTipoAfiliacion(string tipoAfiliacion)
        {
            List<RegimenContributivo> pacientesContributivos = GetAll();

            foreach (var item in pacientesContributivos)
            {
                if (item.TipoAfiliacion == tipoAfiliacion)
                {
                    return item;
                }
            }
            return null;
        }

        public RegimenContributivo Mapper(string linea)
        {
            var paciente = new RegimenContributivo();
            string[] datos = linea.Split(';');
            paciente.NumeroLiquidacion = datos[0];
            paciente.IdPaciente = datos[1];
            paciente.TipoAfiliacion = datos[2];
            paciente.SalarioDevengadoPaciente = float.Parse(datos[3]);
            paciente.CuotaModeradora = float.Parse(datos[4]);
            paciente.Tarifa = float.Parse(datos[5]);
            paciente.TopeMaximo = datos[6];
            paciente.ValorServicioPrestado = float.Parse(datos[7]);
            return paciente;
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

        public void ActualizarLista(List<RegimenContributivo> Pacientes)
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
