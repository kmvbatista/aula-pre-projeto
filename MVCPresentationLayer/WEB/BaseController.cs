using MvcPresentationLayer.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentationLayer.WEB
{
    public class BaseController : Controller
    {
        //Antes de executar qualquer método do controller
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrWhiteSpace(Cookie.Get(Cookie.CookieName)))
            {
                filterContext.Result = new RedirectResult(Url.Action("Index", "Login"));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}