using EventManagemenetApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Interface
{
    public interface IRegistration
    {
        int AddUser(Registration entity);
        void AddAdmin(Registration entity);
        bool CheckUserNameExists(string Username);
        RegistrationViewModel Userinformation(int UserID);
        IQueryable<RegistrationViewModel> UserinformationList(string sortColumn, string sortColumnDir, string Search);
    }
}
