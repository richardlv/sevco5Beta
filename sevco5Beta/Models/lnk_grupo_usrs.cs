using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sevco5Beta.Models
{
    public class lnk_grupo_usrs
    {
        [Key]
        public int Id_grupousr { get; set; }
        public int Id_grupo { get; set; }
        public int Id_usuario { get; set; }
    }
}