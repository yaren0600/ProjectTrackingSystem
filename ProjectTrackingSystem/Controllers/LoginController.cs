using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTrackingSystem.Models; // Include the namespace for the database context and models

namespace ProjectTrackingSystem.Controllers
{

    public class LoginController : Controller
    {
        ProjectTrackingEntities entity = new ProjectTrackingEntities(); // Create an instance of the database context
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    }
}