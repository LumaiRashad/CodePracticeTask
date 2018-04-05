using QASystemTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QASystemTask.ViewModels;
using QASystemTask.Models;
using System.Data.Entity;

namespace QASystemTask.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        DBEntities DBContext = new DBEntities();

        #region Get All Question in Database
        public ActionResult Index()
        {
            return View(DBContext.QuestionDBTables.ToList());
        }
        #endregion

        #region Post a Question
        public ActionResult GetQuestion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateQuestion(QuestionDBTable Obj)
        {
            if (!ModelState.IsValid)
                return View("GetQuestion", Obj);
            try
            {
                Obj.UserName = User.Identity.Name;
                DBContext.QuestionDBTables.Add(Obj);
                DBContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("GetQuestion", Obj);
            }
        }
        #endregion

        #region Edit Question
        public ActionResult EditQuestion(int id)
        {
            TempData["QuestionIDKey"] = id;
            return View();
        }
        public ActionResult UpdateQuestion(QuestionDBTable Obj)
        {
            int QuestionIDKey = Convert.ToInt32(TempData["QuestionIDKey"]);
            Obj.UserName = User.Identity.Name;
            if (!ModelState.IsValid)
                return View("EditQuestion", Obj);
            try
            {
                QuestionDBTable Temp = DBContext.QuestionDBTables.SingleOrDefault(x => x.ID == QuestionIDKey);
                if(Temp != null)
                {
                    Temp.QuestionString = Obj.QuestionString;
                    DBContext.Entry(Temp).State = EntityState.Modified;
                    DBContext.SaveChanges();
                }
            }
            catch
            {
                return View("EditQuestion", Obj);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Delete Question
        public ActionResult DeleteQuestion(int id)
        {
            QuestionDBTable Temp = DBContext.QuestionDBTables.FirstOrDefault(x => x.ID == id);
            if(Temp!= null)
            {
                DBContext.QuestionDBTables.Remove(Temp);
                DBContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return HttpNotFound();
        }
        #endregion
    }
}