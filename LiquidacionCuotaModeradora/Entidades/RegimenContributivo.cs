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

        public override void CalcularCuotaModeradora()
        {
            float ValidarCuotaModeradora = ValorServicioPrestado * Tarifa;

            if (ValidarCuotaModeradora > 250000f)
            {
                CuotaModeradora = 250000f;
            } 
            else if (ValidarCuotaModeradora > 900000f)
            {

            }


        }

        public override void CalcularTarifa()
        {
            float SMLMV = 1160000f;

            if (SalarioDevengadoPaciente < (2 * SMLMV))
            {
                Tarifa = 0.15f;
            }
            else if (SalarioDevengadoPaciente >= (2 * SMLMV) && SalarioDevengadoPaciente <= (5 * SMLMV))
            {
                Tarifa = 0.20f;
            }
            else if (SalarioDevengadoPaciente > (5 * SMLMV))
            {
                Tarifa = 0.25f;
            }
        }
    }
}
