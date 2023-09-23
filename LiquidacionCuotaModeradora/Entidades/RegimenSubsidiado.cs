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
        public float ValorServicioPrestado { get; set; }

        public RegimenSubsidiado(string NumeroLiquidacion, string IdPaciente, string TipoAfiliacion, float SalarioDevengadoPaciente, float cuotaModeradora, float valorServicioPrestado, float topeValorCuota)
        : base(NumeroLiquidacion, IdPaciente, TipoAfiliacion, SalarioDevengadoPaciente, cuotaModeradora)
        {
            TipoAfiliacion = "Subsidiado";
            ValorServicioPrestado = valorServicioPrestado;
        }

        public override float CalcularCuotaModeradora(float Tarifa)
        {
            float ValidarCuotaModeradora = ValorServicioPrestado * Tarifa;
            return ValidarCuotaModeradora;
        }

        public override void ValidarCuotaModeradora()
        {
            float Tarifa = 0.05f;
            if(CalcularCuotaModeradora(Tarifa) > 200000)
            {
                CuotaModeradora = 200000;
            }
            else
            {
                CuotaModeradora = CalcularCuotaModeradora(Tarifa);
            }
        }

        public override string ToString()
        {
            return $"{NumeroLiquidacion};{IdPaciente};{TipoAfiliacion};{SalarioDevengadoPaciente};{CuotaModeradora};{ValorServicioPrestado};{TopeValorCuota}";
        }
    }
}
