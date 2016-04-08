using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sevco5Beta.Filtros
{
    public class AdminFiltro:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!Convert.ToBoolean(filterContext.HttpContext.Session["isAdmin"]))
            {
                filterContext.Result = new ContentResult()
                {
                    Content = "No cuenta con la autorizacion para ver el contenido"
                };
            }
        }

    }
}