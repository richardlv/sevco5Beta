using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sevco5Beta.Models
{
    public class metas
    {
        [Key]
        public int Id_meta { get; set; }
        public string NombreMeta { get; set; }
        public bool IsTi { get; set; }
    }
}