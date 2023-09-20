using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RegimenSubsidiado : Paciente
    {
        public RegimenSubsidiado(){ }
        public float Tarifa { get; set; }
        public float ValorServicioPrestado { get; set; }
        public float TopeValorCuota { get; set; }

        public RegimenSubsidiado(string NumeroLiquidacion, string IdPaciente, string TipoAfiliacion, float SalarioDevengadoPaciente, float cuotaModeradora, float tarifa, float valorServicioPrestado, float topeValorCuota)
        : base(NumeroLiquidacion, IdPaciente, TipoAfiliacion, SalarioDevengadoPaciente, cuotaModeradora)
        {
            Tarifa = tarifa;
            ValorServicioPrestado = valorServicioPrestado;
            TopeValorCuota = topeValorCuota;
        }
    }
}
