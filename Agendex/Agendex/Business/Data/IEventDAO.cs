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
        bool DeleteEvent(Models.Event e);
        bool DeleteConfirmedEvent(Models.Event e);
        bool CompanySubmitEvent(Models.Event e);
    }
}
