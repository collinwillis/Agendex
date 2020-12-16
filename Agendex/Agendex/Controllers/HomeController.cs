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
        public User currentUser = null;
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

        public ActionResult CompanyHome()
        {
            
            return View();
        }

        public JsonResult PopulateEvents(DateTime start, DateTime end)
        {
            List<Event> databaseEvents;
            if ((Company)HttpContext.Session["currentCompany"] == null)
            {
                User currentUser = (User)HttpContext.Session["currentUser"];
                int id = _securityService.FetchAssociatedCompanyID(currentUser);
                Company c = _securityService.CompanyFromId(id);
                databaseEvents = _securityService.GetConfirmedEvents(c);
            }
            else
            {
                Company currentCompany = (Company)HttpContext.Session["currentCompany"];
                databaseEvents = _securityService.GetConfirmedEvents(currentCompany);
            }
            var events = new List<ViewEvent>();
            for (int i = 0; i < databaseEvents.Count; i++)
            {
                events.Add(new ViewEvent()
                {
                    id = databaseEvents[i].ID,
                    title = "Event: " + databaseEvents[i].EventName,
                    start = databaseEvents[i].StartDate,
                    end = databaseEvents[i].EndDate,
                    description = databaseEvents[i].EventDescription
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }
            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }

            public ActionResult UserHome()
        {
            return View("UserHome");
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
                    return UserHome();
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
            int currentUsersCompanyID = _securityService.FetchAssociatedCompanyID((User)HttpContext.Session["currentUser"]);

            e.CompanyId = currentUsersCompanyID;

            bool success = _securityService.SubmitEvent(e);

            if (success)
            {
                return View("EventCreationSuccess", e);
            }
            else
            {
                return View("EventCreationFailed");
            }
        }

        public ActionResult CompanyCreateEvent()
        {
            return View("CompanyEventCreation");
        }

        public ActionResult CompanySubmitEvent(Models.Event e)
        {
            Company c = (Company)HttpContext.Session["currentCompany"];

            e.CompanyId = c.ID;

            bool success = _securityService.CompanySubmitEvent(e);

            if (success)
            {
                return View("CompanyEventCreationSuccess", e);
            }
            else
            {
                return View("EventCreationFailed");
            }
        }

        public ActionResult ViewRequestedEvents()
        {
            Company c = (Company)HttpContext.Session["currentCompany"];
            List<Event> requestedEvents = _securityService.GetRequestedEvents(c);
            return View("ViewRequestedEvents", requestedEvents);
        }


        public ActionResult AcceptEvent(int Id)
        {
            Event acceptedEvent = _securityService.EventFromId(Id);
            _securityService.ConfirmEvent(acceptedEvent);
            _securityService.DeleteEvent(Id);
            return ViewRequestedEvents();
        }

        public ActionResult DeleteEvent(int Id)
        {
            _securityService.DeleteEvent(Id);
            return ViewRequestedEvents();
        }


    }
}