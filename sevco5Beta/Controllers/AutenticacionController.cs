using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sevco5Beta.Models;
using System.Web.Security;


namespace sevco5Beta.Controllers
{
    public class AutenticacionController : Controller
    {
        //
        // GET: /Autenticacion/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(usuarios userData)
        {
            
            if(ModelState.IsValid)
            {
                BusinessLayer bl = new BusinessLayer();
                UserStatus status = bl.ValidarUsuario(userData);
                bool isAdmin = false;
                if(status==UserStatus.AuthenticatedAdmin)
                {
                    isAdmin = true;
                }
                else if(status==UserStatus.AuthentucatedUser)
                {
                    isAdmin = false;
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");   
                }
                FormsAuthentication.SetAuthCookie(userData.usuario, false);
                Session["isAdmin"] = isAdmin;
                return RedirectToAction("../Dominios/DominiosList");

            }
            else
            {
                return View("Login");
            }
            
            
           
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }



            
	}
}