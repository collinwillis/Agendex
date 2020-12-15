using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendex.Business.Data
{
    public interface ISecurityDAO
    {
        bool AuthenticateUserInDB(Models.User user);
        Models.User ReturnUserFromDB(Models.User user);
        int FetchAssociatedCompanyID(Models.User user);
        bool AuthenticateCompanyInDB(Models.Company company);
        Models.Company ReturnCompanyFromDB(Models.Company company);
        bool RegisterUser(Models.User user);
        bool RegisterCompany(Models.Company company);
    }
}
