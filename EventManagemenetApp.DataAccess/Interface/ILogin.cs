using EventManagemenetApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Interface
{
    public interface ILogin
    {
        Task<Registration> Login(string userName, string passWord);
        bool UpdatePassword(Registration Registration);
    }
}
