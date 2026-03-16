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

        [HttpPost]// Handle the login form submission
        public ActionResult Index(string username, string password)
        {
            var user = (from u in entity.Users
                        where u.userName == username && u.userPassword == password
                        select u).FirstOrDefault(); // Query the database for a user with the provided username and password
            if(user != null)
            {
                // session variables to store user information for the duration of the user's session
                Session["userFullName"] = user.userFullName; // Store the user's full name in the session
                Session["userId"] = user.userId; // Store the user's ID in the session
                Session["userClassId"] = user.userClassId; // Store the user's class ID in the session
                Session["userRoleId"] = user.userRoleId; // Store the user's role ID in the session

                switch (user.userRoleId) // Redirect the user to different pages based on their role ID
                {
                    case 1: // If the user is a project manager
                        return RedirectToAction("ProjectManagerDashboard", "ProjectManager"); // Redirect to the project manager dashboard
                    case 2: // If the user is a team member
                        return RedirectToAction("TeamMemberDashboard", "TeamMember"); // Redirect to the team member dashboard
                    default:
                        break;
                }
                return RedirectToAction("Index", "Home"); // Redirect to the home page if login is successful
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password"; // Display an error message if login fails
                return View(); // Return the login view to allow the user to try again
            }
               
           
        }
        
    }
}