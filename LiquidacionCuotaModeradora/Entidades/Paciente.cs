using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Paciente
    {
        public Paciente() {     }
        public string NumeroLiquidacion { get; set; }
        public string IdPaciente { get; set; }
        public string TipoAfiliacion { get; set; }
        public float SalarioDevengadoPaciente { get; set; }
        public float CuotaModeradora { get; set; }

        public Paciente(string numeroLiquidacion, string idPaciente, string tipoAfiliacion, float salarioDevengadoPaciente, float cuotaModeradora)
        {
            NumeroLiquidacion = numeroLiquidacion;
            IdPaciente = idPaciente;
            TipoAfiliacion = tipoAfiliacion;
            SalarioDevengadoPaciente = salarioDevengadoPaciente;
            CuotaModeradora = cuotaModeradora;
        }

        public abstract float CalcularCuotaModeradora(float Tarifa);
        public abstract void ValidarCuotaModeradora();
    }
}
