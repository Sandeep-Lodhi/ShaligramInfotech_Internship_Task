using SanjayTest.AuthActionFilter;
using SanjayTest.Model.Model;
using SanjayTest.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanjayTest.Controllers
{
    [Authorization]
    public class HomeController : Controller
    {
        public static ResultModel resultModelS = new ResultModel();

        IHomeInterface homeInterface;

        public HomeController(IHomeInterface homeInterface)
        {
            this.homeInterface = homeInterface;
        }
        public ActionResult StartQuiz()
        {
            return View();
        }

        public ActionResult ShowResult()
        {
            try
            {
                if (resultModelS != null)
                {
                    return View(resultModelS);
                }
                return View();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult GetResultData(ResultModel resultModel)
        {
            resultModelS = resultModel;
            return Json("Quiz Submitted Successfully");
        }

        public ActionResult GetQuestionById(int QId)
        {
            try
            {
                return Json(homeInterface.GetQuestionById(QId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}