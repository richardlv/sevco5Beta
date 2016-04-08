using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sevco5Beta.ViewModels;
using sevco5Beta.Models;


namespace sevco5Beta.Controllers
{
    public class ProcesosController : Controller
    {
        //
        // GET: /Procesos/

        
        public ActionResult Procesosinfo()
        {
            return View();
        }




        public ActionResult EvaluacionesList(int ID)//7 Id de proceso
        {
            BusinessLayer bl = new BusinessLayer();
            EvaluacionesListaViewModel elist = new EvaluacionesListaViewModel();
            
            
            List<Evaluaciones> evas = bl.getEvaluaciones_xproces(ID);
            elist.ListaEvaluaciones=evas;
            
            return View(elist);
        }

       
        public ActionResult ProcesosList(int ID)
        {
            
            BusinessLayer bl = new BusinessLayer();
            ProcesoListViewModel pl = new ProcesoListViewModel();
            List<procesos> procs = bl.getProcesos(ID);
            
            pl.ProcesosLista = procs;
            return View(pl);
            
        }


        public ActionResult PreguntasList(int ID)
        {

            BusinessLayer bl = new BusinessLayer();
            PreguntasListViewModel pl = new PreguntasListViewModel();
            List<preguntas> pregs = bl.getPreguntas(ID);
            pl.id_proceso = ID;
            pl.PreguntasLista = pregs;
            return View(pl);

        }

        public ActionResult procesarDatos(IEnumerable<proceso_respuestas> respuestas, string btnSubmit, int Id_proceso)
        {
            BusinessLayer bl = new BusinessLayer();
            Evaluaciones eva = new Evaluaciones();
            int Id_evaluacion=0;
            switch(btnSubmit)
            {
               
                case "Guardar":

                    int sumaresultados=0;
                    foreach (proceso_respuestas item in respuestas)
                    {
                        sumaresultados += item.Resultado;

                    }
                    
                    
                    eva.Id_proceso = Id_proceso;
                    eva.Resultado= sumaresultados / respuestas.Count();
                    eva.fechaEvaluacion = DateTime.Now;
                    Id_evaluacion = bl.CreateEvaluacion(eva);


                    foreach (proceso_respuestas item in respuestas)
                    {
                        item.Id_evaluacion = Id_evaluacion;
                        sumaresultados += item.Resultado;

                        bl.SaveRespuestasPreguntas(item);
                    }
                   
                    return RedirectToAction("../Dominios/DominiosList");

                case "Cancelar":
                    return RedirectToAction("../Dominios/DominiosList");

            }

            return RedirectToAction("~/Dominios/DominiosList");

        }


        


	}
}