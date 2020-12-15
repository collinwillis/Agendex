using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agendex.Models;
using Agendex.Data;

namespace Agendex.Controllers
{
    public class HomeController : Controller
    {
        static Models.User currentUser = null;
        private SecurityDAO dao = new SecurityDAO();
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
            bool success = dao.RegisterUser(u);
            if (success)
            {
                User newUser = dao.returnUserFromDB(u);
                return View("UserRegistered", newUser);
            }
            else
            {
                return View("UserRegisterFailed");
            }

            
        }

        public ActionResult OnRegisterCompany(Company c)
        {
            bool success = dao.RegisterCompany(c);
            if (success)
            {
                Company newCompany = dao.returnCompanyFromDB(c);
                return View("CompanyRegistered", newCompany);
            }
            else
            {
                return View("CompanyRegisterFailed");
            }


        }


        public ActionResult SubmitUserLogin(User u)
        {

                bool success = dao.userInDB(u);
                if (success)
                {
                    User foundUser = dao.returnUserFromDB(u);
                    HttpContext.Session["currentUser"] = foundUser;
                    return View("UserHome", foundUser);

                }
                else
                {
                    return View("LoginFailed");
                }
                
        }

        public ActionResult SubmitCompanyLogin(Company c)
        {

            bool success = dao.CompanyInDB(c);
            if (success)
            {
                Company foundCompany = dao.returnCompanyFromDB(c);
                HttpContext.Session["currentCompany"] = foundCompany;
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
    }
}