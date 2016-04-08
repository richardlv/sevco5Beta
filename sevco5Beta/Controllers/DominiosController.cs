using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sevco5Beta.ViewModels;
using sevco5Beta.Models;
using sevco5Beta.Filtros;


namespace sevco5Beta.Controllers
{
    public class DominiosController : Controller
    {
        //
        // GET: /Dominios/
        public ActionResult Index()
        {
            return View();
        }

        [AdminFiltro]
        public ActionResult DominiosList()
        {
            BusinessLayer bl = new BusinessLayer();
            DominiosListViewModel doml = new DominiosListViewModel();
            List<dominios> doms = bl.getDominios();
            doml.DominiosList = doms;
            return View(doml);
        }

        [AdminFiltro]
        public ActionResult GetDominiosMenu()
        {

            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                BusinessLayer bl = new BusinessLayer();
                DominiosListViewModel doml = new DominiosListViewModel();
                List<dominios> doms = bl.getDominios();
                doml.DominiosList = doms;

                return PartialView("~/Views/Shared/DominiosMenu.cshtml", doml);
            }
            else
            {
                return new EmptyResult();
            }

            
        }

	}
}