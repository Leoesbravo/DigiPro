﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
   public class Materia
    {
        [Required]
        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public List<object> Materias { get; set; }
    }
}
