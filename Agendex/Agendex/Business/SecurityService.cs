using Agendex.Business.Data;
using Agendex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agendex.Business
{
    public class SecurityService : ISecurityService
    {

        private ISecurityDAO securityDAO;
        private IEventDAO eventDAO;

        public SecurityService(ISecurityDAO isecurityDAO, IEventDAO ieventDAO)
        {
            securityDAO = isecurityDAO;
            eventDAO = ieventDAO;
        }

        public bool AuthenticateCompany(Company company)
        {
            return securityDAO.AuthenticateCompanyInDB(company);
        }

        public bool AuthenticateConfirmedEvent(Event e)
        {
            return eventDAO.AuthenticateConfirmedEvent(e);
        }

        public bool AuthenticateEvent(Event e)
        {
            return eventDAO.AuthenticateEvent(e);
        }

        public bool AuthenticateUser(User user)
        {
            return securityDAO.AuthenticateUserInDB(user);
        }

        public bool ConfirmEvent(Event e)
        {
            return eventDAO.ConfirmEvent(e);
        }

        public int FetchAssociatedCompanyID(User user)
        {
            return securityDAO.FetchAssociatedCompanyID(user);
        }

        public bool RegisteredCompany(Company company)
        {
            return securityDAO.RegisterCompany(company);
        }

        public bool RegisteredUser(User user)
        {
            return securityDAO.RegisterUser(user);
        }

        public Company ReturnAuthenticatedCompany(Company company)
        {
            return securityDAO.ReturnCompanyFromDB(company);
        }

        public User ReturnAuthenticatedUser(User user)
        {
            return securityDAO.ReturnUserFromDB(user);
        }

        public bool SubmitEvent(Event e)
        {
            return eventDAO.SubmitEvent(e);
        }

        public bool CompanySubmitEvent(Event e)
        {
            return eventDAO.CompanySubmitEvent(e);
        }

        public List<Event> GetRequestedEvents(Company c)
        {
            return eventDAO.GetRequestedEvents(c);
        }

        public Event EventFromId(int id)
        {
            return eventDAO.EventFromId(id);
        }

        public bool DeleteEvent(int id)
        {
            return eventDAO.DeleteEvent(id);
        }

        public bool DeleteConfirmedEvent(int id)
        {
            return eventDAO.DeleteConfirmedEvent(id);
        }

        public List<Event> GetConfirmedEvents(Company c)
        {
            return eventDAO.GetConfirmedEvents(c);
        }

        public Company CompanyFromId(int id)
        {
            return securityDAO.CompanyFromId(id);
        }
    }
}