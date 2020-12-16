using Agendex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendex.Business
{
    public interface ISecurityService
    {
        bool AuthenticateUser(User user);
        Models.User ReturnAuthenticatedUser(User user);
        bool AuthenticateCompany(Company company);
        Models.Company ReturnAuthenticatedCompany(Company company);
        bool RegisteredUser(User user);
        bool RegisteredCompany(Company company);
        bool AuthenticateConfirmedEvent(Event e);
        bool AuthenticateEvent(Event e);
        bool SubmitEvent(Event e);

        bool CompanySubmitEvent(Models.Event e);

        List<Models.Event> GetRequestedEvents(Company c);

        Event EventFromId(int id);

        bool DeleteEvent(int id);
        bool DeleteConfirmedEvent(int id);


        //Inserts Event from Events Table into ConfirmedEvents Table
        bool ConfirmEvent(Event e);

        int FetchAssociatedCompanyID(Models.User user);


    }
}
