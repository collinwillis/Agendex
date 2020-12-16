using Agendex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendex.Business.Data
{
    public interface IEventDAO
    {

        bool SubmitEvent(Models.Event e);
        bool AuthenticateEvent(Models.Event e);
        bool ConfirmEvent(Models.Event e);
        bool AuthenticateConfirmedEvent(Models.Event e);
        bool DeleteEvent(int id);
        bool DeleteConfirmedEvent(int id);
        bool CompanySubmitEvent(Models.Event e);
        List<Event> GetRequestedEvents(Company c);
        Event EventFromId(int id);
        List<Event> GetConfirmedEvents(Company c);
    }
}
