using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Filters
{
    public class SessionTimeoutAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["UID"] ==null)
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

    }

  
}