using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwEcommerce.Controllers
{
    public class InicialController : Controller
    {
        // GET: Inicial
        public ActionResult Index()
        {
            Session["Compras"] = null;
            return View();
        }
    }
}