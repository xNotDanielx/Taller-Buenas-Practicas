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
        public string TopeMaximo { get; set; }
        public float ValorServicioPrestado { get; set; }

        public RegimenSubsidiado(string NumeroLiquidacion, string IdPaciente, string TipoAfiliacion, float SalarioDevengadoPaciente, float valorServicioPrestado)
        : base(NumeroLiquidacion, IdPaciente, TipoAfiliacion, SalarioDevengadoPaciente)
        {
            ValorServicioPrestado = valorServicioPrestado;
        }

        public override float CalcularCuotaModeradora(float Tarifa)
        {
            float ValidarCuotaModeradora = ValorServicioPrestado * Tarifa;
            return ValidarCuotaModeradora;
        }

        public override void ValidarCuotaModeradora()
        {
            Tarifa = 0.05f;
            if(CalcularCuotaModeradora(Tarifa) > 200000)
            {
                TopeMaximoSi();
                CuotaModeradora = 200000;
            }
            else
            {
                TopeMaximoNo();
                CuotaModeradora = CalcularCuotaModeradora(Tarifa);
            }
        }

        public override void TopeMaximoSi()
        {
            TopeMaximo = "Si";
        }

        public override void TopeMaximoNo()
        {
            TopeMaximo = "No";
        }

        public override string ToString()
        {
            return $"{NumeroLiquidacion};{IdPaciente};{TipoAfiliacion};{SalarioDevengadoPaciente};{CuotaModeradora};{Tarifa};{TopeMaximo};{ValorServicioPrestado}";
        }
    }
}
