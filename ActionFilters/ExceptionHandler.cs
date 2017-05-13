using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ActionFilters
{
    public class ExceptionHandler:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                filterContext.HttpContext.Response.Write("<br/>" + filterContext.Exception.Message);
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult() { ViewName = "Error" };
            }
        }
    }
}l