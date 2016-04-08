using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sevco5Beta.Models
{
    public class Evaluaciones
    {
        [Key]
        public int Id_evaluacion { get; set; }
        public DateTime fechaEvaluacion { get; set; }
        public int Id_proceso { get; set; }
        public int? Resultado { get; set; }
    }
}