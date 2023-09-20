using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RegimenContributivo : Paciente
    {
        public RegimenContributivo() { }
        public float Tarifa { get; set; }
        public float ValorServicioPrestado { get; set; }

        public RegimenContributivo(string NumeroLiquidacion, string IdPaciente, string TipoAfiliacion, float SalarioDevengadoPaciente, float cuotaModeradora, float tarifa, float valorServicioPrestado)
            : base(NumeroLiquidacion, IdPaciente, TipoAfiliacion, SalarioDevengadoPaciente, cuotaModeradora)
        {
            Tarifa = tarifa;
            ValorServicioPrestado = valorServicioPrestado;
        }
    }
}
