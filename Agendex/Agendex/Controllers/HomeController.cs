using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agendex.Models;
using Agendex.Business;

namespace Agendex.Controllers
{
    public class HomeController : Controller
    {
        static User currentUser = null;
        static Company currentCompany = null;
        private ISecurityService _securityService;

        public HomeController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        public ActionResult RegisterCompany()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            return View();
        }

        public ActionResult CompanyLogin()
        {
            return View();
        }

        public ActionResult OnRegisterUser(User u)
        {
            bool success = _securityService.RegisteredUser(u);
            if (success)
            {
                User newUser = _securityService.ReturnAuthenticatedUser(u);
                return View("UserRegistered", newUser);
            }
            else
            {
                return View("UserRegisterFailed");
            }

            
        }

        public ActionResult OnRegisterCompany(Company c)
        {
            bool success = _securityService.RegisteredCompany(c);
            if (success)
            {
                Company newCompany = _securityService.ReturnAuthenticatedCompany(c);
                return View("CompanyRegistered", newCompany);
            }
            else
            {
                return View("CompanyRegisterFailed");
            }


        }


        public ActionResult SubmitUserLogin(User u)
        {

                bool success = _securityService.AuthenticateUser(u);
                if (success)
                {
                User foundUser = _securityService.ReturnAuthenticatedUser(u);
                    HttpContext.Session["currentUser"] = foundUser;
                currentUser = foundUser;
                    return View("UserHome", foundUser);
                }
                else
                {
                    return View("LoginFailed");
                }
                
        }

        public ActionResult SubmitCompanyLogin(Company c)
        {

            bool success = _securityService.AuthenticateCompany(c);
            if (success)
            {
                Company foundCompany = _securityService.ReturnAuthenticatedCompany(c);
                HttpContext.Session["currentCompany"] = foundCompany;
                currentCompany = foundCompany;
                return View("CompanyHome", foundCompany);
            }
            else
            {
                return View("LoginFailed");
            }

        }

        public ActionResult CreateEvent()
        {
            return View("EventCreation");
        }

        public ActionResult SubmitEvent(Models.Event e)
        {
            int currentUsersCompanyID = _securityService.FetchAssociatedCompanyID(currentUser);

            e.CompanyId = currentUsersCompanyID;

            bool success = _securityService.SubmitEvent(e);

            if (success)
            {
                return View("EventCreationSuccess");
            }
            else
            {
                return View("EventCreationFailed");
            }
        }
    }
}