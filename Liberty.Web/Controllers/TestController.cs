using Liberty.Web.Models.TestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liberty.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var model = new HtmlElementModel();
            model.AvailableItems.Add(new SelectListItem { Text = "Seçiniz", Selected = true, Disabled = true, Value = "1" });
            model.AvailableItems.Add(new SelectListItem { Text = "Edge", Value = "1" });
            model.AvailableItems.Add(new SelectListItem { Text = "Ekin", Value = "2" });
            return View(model);
        }
    }
}