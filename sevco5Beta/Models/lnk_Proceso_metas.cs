using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace sevco5Beta.Models
{
    public class lnk_Proceso_metas
    {
        [Key]
        public int Id_pro_meta { get; set; }
        public int Id_proceso { get; set; }
        public int Id_meta { get; set; }

    }
}