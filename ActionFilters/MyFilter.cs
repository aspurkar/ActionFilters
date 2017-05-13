using ActionFilters.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ActionFilters
{
    public class MyFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<br/>OnActionExecuting....");
            filterContext.HttpContext.Response.Write("<br/>Action:" + filterContext.ActionDescriptor.ActionName);
            foreach (var param in filterContext.ActionParameters)
            {
                filterContext.HttpContext.Response.Write("<br/>Key:" + param.Key + " Value:" + param.Value);
            }
           
            //var id = (string)filterContext.RouteData.Values["id"];
            //Customer c = new Customer();
            //c.Id = int.Parse(id);
            //filterContext.ActionParameters["c"] = c;

           // filterContext.Result = new ViewResult() { ViewName = "NotFound" };
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                filterContext.HttpContext.Response.Write("<br/>" + filterContext.Exception.Message);
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult() { ViewName = "Error" };
            }
            filterContext.HttpContext.Response.Write("<br/>OnActionExecuted....");
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<br/>OnResultExecuting....");
           
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<br/>OnResultExecuted....");
            filterContext.HttpContext.Response.Headers.Add("MyCustomHeader", DateTime.Now.ToString("U"));
        }
    }
}