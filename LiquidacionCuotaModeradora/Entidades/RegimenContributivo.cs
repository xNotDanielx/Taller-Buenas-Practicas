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
        public string TopeMaximo { get; set; }
        public float ValorServicioPrestado { get; set; }

        public RegimenContributivo(string NumeroLiquidacion, string IdPaciente, string TipoAfiliacion, float SalarioDevengadoPaciente, float valorServicioPrestado)
            : base(NumeroLiquidacion, IdPaciente, TipoAfiliacion, SalarioDevengadoPaciente)
        {
            ValorServicioPrestado = valorServicioPrestado;
        }

        public override float CalcularCuotaModeradora(float Tarifa)
        {
            float ValidarCuotaModeradora = ValorServicioPrestado * Tarifa;
            return ValidarCuotaModeradora;
        }

        public override void TopeMaximoSi()
        {
            TopeMaximo = "Si";
        }

        public override void TopeMaximoNo()
        {
            TopeMaximo = "No";
        }

        public override void ValidarCuotaModeradora()
        {
            float SMLMV = 1160000f;

            if (SalarioDevengadoPaciente < (2 * SMLMV))
            {
                Tarifa = 0.15f;
                
                if (CalcularCuotaModeradora(Tarifa) > 250000f)
                {
                    TopeMaximoSi();
                    CuotaModeradora = 250000f;
                }
                else
                {
                    TopeMaximoNo();
                    CuotaModeradora = CalcularCuotaModeradora(Tarifa);
                }
            }
            else if (SalarioDevengadoPaciente >= (2 * SMLMV) && SalarioDevengadoPaciente <= (5 * SMLMV))
            {
                Tarifa = 0.20f;
                if (CalcularCuotaModeradora(Tarifa) > 900000f)
                {
                    TopeMaximoSi();
                    CuotaModeradora = 900000f;
                }
                else
                {
                    TopeMaximoNo();
                    CuotaModeradora = CalcularCuotaModeradora(Tarifa);
                }
            }
            else if (SalarioDevengadoPaciente > (5 * SMLMV))
            {
                Tarifa = 0.25f;

                if(CalcularCuotaModeradora(Tarifa) > 1500000f)
                {
                    TopeMaximoSi();
                    CuotaModeradora = 1500000f;
                }
                else
                {
                    TopeMaximoNo();
                    CuotaModeradora = CalcularCuotaModeradora(Tarifa);
                }
            }
        }

        public override string ToString()
        {
            return $"{NumeroLiquidacion};{IdPaciente};{TipoAfiliacion};{SalarioDevengadoPaciente};{CuotaModeradora};{Tarifa};{TopeMaximo};{ValorServicioPrestado}";
        }
    }
}
