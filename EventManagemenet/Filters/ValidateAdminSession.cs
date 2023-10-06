﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EventManagemenet.Filters
{
    public class ValidateAdminSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(context.HttpContext.Session.GetString("RoleID"))))
            {

                string UserCurrentRole = (string)context.HttpContext.Session.GetString("RoleID");

                if (UserCurrentRole != "1") //Admin Role = 1
                {

                    ViewResult result = new ViewResult();
                    result.ViewName = "Error";

                    var controller = context.Controller as Controller;
                    controller.ViewData["ErrorMessage"] = "Invalid User";
                    controller.HttpContext.Session.Clear();
                    context.Result = result;
                }

            }
            else
            {
                ViewResult result = new ViewResult();
                result.ViewName = "Error";

                var controller = context.Controller as Controller;
                controller.ViewData["ErrorMessage"] = "You Session has been Expired";
                controller.HttpContext.Session.Clear();
                context.Result = result;
            }
        }
    }
}
