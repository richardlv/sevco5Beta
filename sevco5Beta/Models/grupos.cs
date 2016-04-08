using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sevco5Beta.Models
{
    public class grupos
    {
        [Key]
        public int Id_grupo { get; set; }
        public string nombre_grupo { get; set; }
        public string descripcion { get; set; }
    }
}