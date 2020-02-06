using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using speak_out.Data;
using speak_out.ViewModels;

namespace speak_out.Controllers
{
    public class LoginController : Controller
    {
        private readonly SpeakOutContext _context;
       // private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(SpeakOutContext context /*SignInManager<ApplicationUser> signInManager*/)
        {
            _context = context;
            //_signInManager = signInManager;
        }
        //Login as user

        //Login POST
       // [HttpPost]
       // [ValidateAntiForgeryToken]
        //Login as user
        public ActionResult LoginAsUser(UserViewModel login, string ReturnUrl = "")
        {
            string message = "";

            var users = _context.Users.FirstOrDefault(a => a.UserName == login.UserName);
            if (users != null)
            {
                if (string.Compare(Crypto.Hash(login.UserPassword), users.UserPassword) == 0)
                {
                    #region ?
                    //int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                    //var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                    //string encrypted = FormsAuthentication.Encrypt(ticket);
                    //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    //cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    //cookie.HttpOnly = true;
                    //Response.Cookies.Add(cookie);
                    //var k = _context.Volunteers.FirstOrDefault(b => b.UserNameV == login.UserNameV);
                    #endregion

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Home", "Home");
                    }
                }
            }
            else
            {
                message = "Invalid credential provided";
            }
            ViewBag.Message = message;
            return View();
        }

        //Login as Volunteer 
        public ActionResult LoginAsVolunteer(VolunteerViewModel loginV, string ReturnUrlV = "")
        {
            string message = "";

            var volunteers = _context.Volunteers.FirstOrDefault(b => b.VolunteerUserName == loginV.VolunteerUserName);
            if (volunteers != null)
            {
                if (string.Compare(Crypto.Hash(loginV.VolunteerPassword), volunteers.VolunteerPassword) == 0)
                {
                    #region ?
                    //int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                    //var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                    //string encrypted = FormsAuthentication.Encrypt(ticket);
                    //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    //cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    //cookie.HttpOnly = true;
                    //Response.Cookies.Add(cookie);
                    //var k = _context.Volunteers.FirstOrDefault(b => b.UserNameV == login.UserNameV);
                    #endregion

                    if (Url.IsLocalUrl(ReturnUrlV))
                    {
                        return Redirect(ReturnUrlV);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                message = "Invalid credential provided";
            }
            ViewBag.Message = message;
            return View();
        }

        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index");
        //}
    }
}