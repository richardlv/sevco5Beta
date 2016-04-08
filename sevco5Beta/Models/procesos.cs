using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sevco5Beta.Models
{
    public class procesos
    {
        [Key]
        public int Id_proceso { get; set; }
        public string Proceso { get; set; }
        public string Descripcion { get; set; }
        public int Id_Dominio { get; set; }


       // public virtual dominios dominio { get; set; }

    }
}