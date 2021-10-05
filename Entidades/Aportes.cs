﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Pedro_2018_0613.Entidades
{
    public class Aportes
    {
        [Key]
        public int AportesId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Persona { get; set; }
        public string Concepto { get; set; }
        public int Monto { get; set; }
    }
}
