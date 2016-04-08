using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sevco5Beta.Models;

namespace sevco5Beta.ViewModels
{
    public class EvaluacionesListaViewModel
    {
        public List<Evaluaciones> ListaEvaluaciones { get; set; }
        public int Id_proceso { get; set; }
    }
}