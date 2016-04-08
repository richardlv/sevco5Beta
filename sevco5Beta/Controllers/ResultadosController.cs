using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sevco5Beta.ViewModels;
using sevco5Beta.Models;



namespace sevco5Beta.Controllers
{
    public class ResultadosController : Controller
    {
        //
        // GET: /Resultados/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ResultadoEvaluaciones(int ID)//7 Id de proceso
        {
            BusinessLayer bl = new BusinessLayer();
            EvaluacionesListaViewModel elist = new EvaluacionesListaViewModel();


            List<Evaluaciones> evas = bl.getEvaluaciones_xproces(ID);
            elist.ListaEvaluaciones = evas;

            return View(elist);
        }






	}
}