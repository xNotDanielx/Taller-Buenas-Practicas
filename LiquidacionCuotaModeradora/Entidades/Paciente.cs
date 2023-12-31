﻿using System;
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

        protected Paciente(string numeroLiquidacion, string idPaciente, string tipoAfiliacion, float salarioDevengadoPaciente)
        {
            NumeroLiquidacion = numeroLiquidacion;
            IdPaciente = idPaciente;
            TipoAfiliacion = tipoAfiliacion;
            SalarioDevengadoPaciente = salarioDevengadoPaciente;            
        }

        public abstract float CalcularCuotaModeradora(float Tarifa);
        public abstract void ValidarCuotaModeradora();
        public abstract void TopeMaximoSi();
        public abstract void TopeMaximoNo();
    }
}
