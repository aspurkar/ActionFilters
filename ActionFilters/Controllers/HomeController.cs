using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionFilters.Controllers
{
    public class HomeController : Controller
    {
        [ExceptionHandler]
        public ActionResult Index()
        {
            throw new Exception("Some error in action index");
            return View();
        }
        public ActionResult show()
        {
            return View();
        }
    }
     public class Customer
     {
         public int Id { get; set; }
     }
}
