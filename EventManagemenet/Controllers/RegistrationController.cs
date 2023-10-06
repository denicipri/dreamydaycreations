using Microsoft.AspNetCore.Mvc;
using EventManagemenetApp.EntityFramework;
using EventManagemenet.PasswordHash;
using NuGet.Protocol.Core.Types;
using EventManagemenetApp.DataAccess.Interface;
using Microsoft.AspNetCore.Rewrite;

namespace EventManagemenet.Controllers
{
    public class RegistrationController : Controller
    {
        IRegistration _IRepository;
        IRoles _IRoles;
        public RegistrationController(IRegistration IRepository, IRoles IRoles)
        {
            _IRepository = IRepository;
            _IRoles = IRoles;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Registration()
        {
            try
            {
                Registration Registration = new Registration();
                Registration.Country = null;
                Registration.City = null;
                Registration.State = null;
                return View(Registration);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(Registration Registration)
        {
            try
            {
                var isUsernameExists = _IRepository.CheckUserNameExists(Registration.Username);

                if (isUsernameExists)
                {
                    ModelState.AddModelError("", errorMessage: "Username Already Used try unique one!");
                }
                else
                {
                    Registration.CreatedOn = DateTime.Now;
                    Registration.RoleID = _IRoles.getRolesofUserbyRolename("Users");
                    Registration.Password = EncryptionLibrary.EncryptText(Registration.Password);
                    Registration.ConfirmPassword = EncryptionLibrary.EncryptText(Registration.ConfirmPassword);
                    if (_IRepository.AddUser(Registration) > 0)
                    {
                        TempData["MessageRegistration"] = "Data Saved Successfully!";
                        return View(Registration);
                    }
                    else
                    {
                        return View(Registration);
                    }
                }

                return View(Registration);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
