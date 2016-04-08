using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sevco5Beta.Models
{
    public class proceso_resultados
    {
        [Key]
        public int Id_pro_res {get;set;}
        public int Resultado {get;set;}
        public int Id_evaluacion {get;set;}
        public DateTime Fecha_creacion { get; set; }
    }
}