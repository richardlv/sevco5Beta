using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sevco5Beta.Models;
using sevco5Beta.ViewModels;
using sevco5Beta.Filtros;

namespace sevco5Beta.Controllers
{
    public class AdminUsuariosController : Controller
    {
        //
        // GET: /AdminUsuarios/
        public ActionResult Index()
        {
            return View();
        }

        [AdminFiltro]
        public ActionResult CrearUsuario()
        {
           /* UsuarioDetalleViewModel usrD = new UsuarioDetalleViewModel();
            BusinessLayer bal = new BusinessLayer();
            usrD.gruposLista = bal.getGrupos();
            */

            return View();
        }


        [HttpPost]
        [AdminFiltro]
        public ActionResult CrearUsuario(usuarios usrDatos, string btnSubmit )
        {
            
            BusinessLayer bal = new BusinessLayer();

            if (ModelState.IsValid)
            {
                bal.CrearNuevo_Usr(usrDatos);
                return RedirectToAction("../Dominios/DominiosList");
            }
            else
            {
                return View("CrearUsuario");
            }

            return new EmptyResult();
        }

	}
}