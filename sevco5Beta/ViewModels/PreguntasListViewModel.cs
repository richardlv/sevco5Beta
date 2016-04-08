using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sevco5Beta.Models;

namespace sevco5Beta.ViewModels
{
    public class PreguntasListViewModel
    {
        public List<preguntas> PreguntasLista { get; set; }
        public int id_proceso { get; set; }
    }
}