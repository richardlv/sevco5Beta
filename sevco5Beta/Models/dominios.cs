using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sevco5Beta.Models
{
    public class dominios
    {
        [Key]
        public int Id_dominio { get; set; }
        public string Nombre_dominio { get; set; }
        public string Descripcion { get; set; }
    }
}