using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sevco5Beta.Models;

namespace sevco5Beta.ViewModels
{
    public class UsuarioDetalleViewModel
    {
        public usuarios usr { get; set; }
        public List<grupos> gruposLista { get; set; }
    }
}