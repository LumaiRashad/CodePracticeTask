using QASystemTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QASystemTask.ViewModels;
using QASystemTask.Models;

namespace QASystemTask.Controllers
{
    [Authorize]
    public class AnswerController : Controller
    {
        DBEntities DBContext = new DBEntities();
        #region Get Answers of Certain Question
        public ActionResult Index(int id)
        {
            IEnumerable<AnswerDBTable> Selected = DBContext.AnswerDBTables.Where(x => x.QuestionID == id);
            List<AnswerDBTable> SelectedAnswers = Selected.ToList();
            QuestionDBTable QuestionSelected = DBContext.QuestionDBTables.First(x => x.ID == id);

            QuestionAnswerViewModel QAViewModel = new QuestionAnswerViewModel
            {
                Question = QuestionSelected,
                Answers = SelectedAnswers
            };

            
            if (SelectedAnswers.Count() == 0)
                return HttpNotFound();
            return View(QAViewModel);
        }
        #endregion

        #region Add Answer
        public ActionResult GetAnswer(int id)
        {
            TempData["QID"] = id;
            return View();
        }
        public ActionResult CreateAnswer(AnswerDBTable Obj)
        {
            int QuesID = Convert.ToInt32(TempData["QID"]);
            Obj.QuestionID = QuesID;

            if (!ModelState.IsValid)
                return View("GetAnswer", Obj);
            try
            {
                DBContext.AnswerDBTables.Add(Obj);
                DBContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("GetAnswer", Obj);
            }
        }
        #endregion
    }
}