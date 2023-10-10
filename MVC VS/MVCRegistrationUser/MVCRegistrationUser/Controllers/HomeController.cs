using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRegistrationUser.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace MVCRegistrationUser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserClass uc,HttpPostedFileBase file)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Sandeep_Phase3Entities"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "INSERT INTO MVCregUser(Uname,Uemail,Upwd,Gender,Uimg) VALUES" + "(@Uname,@Uemail,@Upwd,@Gender,@Uimg)";
            SqlCommand sqlcomn = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomn.Parameters.AddWithValue("@Uname", uc.Uname);
            sqlcomn.Parameters.AddWithValue("@Uemail", uc.Uemail);
            sqlcomn.Parameters.AddWithValue("@Upwd", uc.Upwd);
            sqlcomn.Parameters.AddWithValue("@Gender", uc.Gender);
            if(file!=null && file.ContentLength>0)
            {
                string filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(Server.MapPath("~/User-Images/"), filename);
                file.SaveAs(imgpath);

            }
            sqlcomn.Parameters.AddWithValue("@Uimg", "~/User-Images/" + file.FileName);
            sqlcomn.ExecuteNonQuery();
            sqlconn.Close();
            ViewData["Message"] = "User Record" + uc.Uname + "Is saved sccessfully !";


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}