﻿using EventManagemenet.Filters;
using EventManagemenet.PasswordHash;
using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EventManagemenet.Controllers
{
    [ValidateUserSession]
    public class CustomerController : Controller
    {
        ILogin _ILogin;
        IRegistration _IRegistration;
        public CustomerController(ILogin ILogin, IRegistration IRegistration)
        {
            _ILogin = ILogin;
            _IRegistration = IRegistration;
        }


        // GET: /<controller>/ Userinformation
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(ChangePasswordModel ChangePasswordModel)
        {
            var password = EncryptionLibrary.EncryptText(ChangePasswordModel.Password);
            var registrationModel = _IRegistration.Userinformation(Convert.ToInt32(HttpContext.Session.GetString("UserID")));

            if (registrationModel.Password == password)
            {
                var registration = new Registration();
                registration.Password = EncryptionLibrary.EncryptText(ChangePasswordModel.NewPassword);
                registration.ID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
                var result = _ILogin.UpdatePassword(registration);

                if (result)
                {
                    TempData["MessageUpdate"] = "Password Updated Successfully";
                    ModelState.Clear();
                    return View(new ChangePasswordModel());
                }
                else
                {
                    return View(ChangePasswordModel);
                }
            }
            else
            {
                TempData["MessageUpdate"] = "Invalid Password";
                return View(ChangePasswordModel);
            }
        }
    }
}
