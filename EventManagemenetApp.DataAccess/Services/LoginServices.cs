using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Services
{
    public class LoginServices:ILogin
    {
        private EventContext _context;

        public LoginServices(EventContext context)
        {
            _context = context;
        }

        public async Task<Registration> Login(string userName, string passWord)
        {
            try
            {
                var validate =await (from user in _context.Registration
                                where user.Username == userName && user.Password == passWord
                                select user).SingleOrDefaultAsync();

                return validate;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdatePassword(Registration Registration)
        {
            _context.Registration.Attach(Registration);
            _context.Entry(Registration).Property(x => x.Password).IsModified = true;
            int result = _context.SaveChanges();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
