using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesttaskQuizModel.dbconext;
using TesttaskQuizRepository.Interface;

namespace TesttaskQuiz.Controllers
{
    public class HomeController : Controller
    {
        public Iquiz _iquiz;
        lavan_386Entities dataobj = new lavan_386Entities();
        public HomeController(Iquiz iquiz)
        {
            _iquiz = iquiz;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult DbAnswerList(int id)
        {
            dataobj.Configuration.ProxyCreationEnabled = false;
            var result = dataobj.Answers.Where(x => x.questionId == id).ToList();
            var ans = JsonConvert.SerializeObject(result);
            return Json(ans, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DbQuestionsList(int id)
        {
            dataobj.Configuration.ProxyCreationEnabled = false;
            var result = dataobj.Questions.Where(x => x.id == id).ToList();
            var ans = JsonConvert.SerializeObject(result);
            return Json(ans, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Resultlist(int Id)
        {
            int mar;
            dataobj.Configuration.ProxyCreationEnabled = false;
            var result = dataobj.Answers.Where(x => x.Id == Id && x.isCorrect == true);
            //var marks = JsonConvert.SerializeObject(result);
            if (result.Count()==1)
            {
                 mar = 10;
                return Json(mar, JsonRequestBehavior.AllowGet);
                 
            }
             mar = -5;
            return Json(mar, JsonRequestBehavior.AllowGet);
        }


    }
}