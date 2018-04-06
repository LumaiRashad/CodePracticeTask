using QASystemTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QASystemTask.Controllers
{
    public class UserController : Controller
    {
        #region Registering User
        [HttpGet]
        public ActionResult GetUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(UserTable user)
        {
            DBEntities DBContext = new DBEntities();
            if (!ModelState.IsValid)
                return View("GetUser", user);
            try
            {
                DBContext.UserTables.Add(user);
                DBContext.SaveChanges();
                return RedirectToAction("UserVerified", "User", user);
            }
            catch
            {
                return View("GetUser", user);
            }
        }

        public ActionResult UserVerified(UserTable user)
        {
            return View();
        }
        #endregion

        #region Log in User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin user, string ReturnUrl)
        {
            DBEntities DBContext = new DBEntities();
            var Temp = DBContext.UserTables.Where(x => x.UserName == user.UserName).FirstOrDefault();

            if(Temp != null)
            {
                if (string.Compare(Temp.Password, user.Password) == 0)
                {
                    int timeout = user.RememberMe ? 525000 : 20;
                    var ticket = new FormsAuthenticationTicket(user.UserName, user.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Password is wrong.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Username is wrong.");
            }
            return View("Login", user);
        }
        #endregion

        #region Log out User
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
        #endregion

        #region Log out View
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Get All User's Questions & their Answers
        [Authorize]
        public ActionResult ListQuestions(string id)
        {
            DBEntities DBContext = new DBEntities();
            IEnumerable<QuestionDBTable> Selected = DBContext.QuestionDBTables.Where(x => Equals(x.UserName, id));
            List<QuestionDBTable> SelectedQuestions = Selected.ToList();
            return View(SelectedQuestions);
        }
        #endregion

        #region Get User's Details
        [Authorize]
        public ActionResult UserDetails(string id)
        {
            DBEntities DBContext = new DBEntities();
            UserTable User = DBContext.UserTables.SingleOrDefault(x => Equals(x.UserName, id));
            return View(User);
        }
        #endregion
    }
}