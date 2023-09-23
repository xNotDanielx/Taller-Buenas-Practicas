using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioRegimenSubsidiado : IRegimen<RegimenSubsidiado>
    {
        string ruta = "Pacientes_Regimen_Subsidiado.txt";
        public void GuardarPaciente(RegimenSubsidiado paciente)
        {
            StreamWriter writer = new StreamWriter(ruta, true);
            writer.WriteLine(paciente.ToString());
            writer.Close();
        }

        public RegimenSubsidiado BuscarPorId(string identificacion)
        {
            List<RegimenSubsidiado> pacientesSubsidiados = GetAll();

            foreach (var item in pacientesSubsidiados)
            {
                if (item.IdPaciente == identificacion)
                {
                    return item;
                }
            }
            return null;
        }

        public RegimenSubsidiado BuscarPorNumeroLiquidacion(string numeroLiquidacion)
        {
            List<RegimenSubsidiado> pacientesSubsidiados = GetAll();

            foreach (var item in pacientesSubsidiados)
            {
                if (item.NumeroLiquidacion  == numeroLiquidacion)
                {
                    return item;
                }
            }
            return null;
        }

        public RegimenSubsidiado Mapper(string linea)
        {
            var Paciente = new RegimenSubsidiado();
            string[] datos = linea.Split(';');
            Paciente.NumeroLiquidacion = datos[0];
            Paciente.IdPaciente = datos[1];
            Paciente.TipoAfiliacion = datos[2];
            Paciente.SalarioDevengadoPaciente = float.Parse(datos[3]);
            Paciente.CuotaModeradora = float.Parse(datos[4]);
            Paciente.ValorServicioPrestado = float.Parse(datos[5]);
            return Paciente;
        }

        public List<RegimenSubsidiado> GetAll()
        {
            try
            {
                List<RegimenSubsidiado> Pacientes = new List<RegimenSubsidiado>();
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

        public void EliminarPaciente(List<RegimenSubsidiado> Pacientes)
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
