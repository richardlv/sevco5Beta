using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sevco5Beta.Models
{
    public class preguntas
    {
        [Key]
        public int Id_pregunta { get; set; }
        public string pregunta { get; set; }
        public int Id_meta { get; set; }

    }
}