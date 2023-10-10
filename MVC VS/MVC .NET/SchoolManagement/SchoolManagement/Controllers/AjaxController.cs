using School.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SchoolManagement.Controllers
{
    public class AjaxController : Controller
    {
        IAjaxInterface _IAjaxInterface;

        public AjaxController(IAjaxInterface ajaxInterface)
        {
            _IAjaxInterface = ajaxInterface;
        }

        public JsonResult GetDepartment()
        {
            try
            {
                var dept=_IAjaxInterface.GetDepartment();
                return Json(dept,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult GetCountry()
        {
            try
            {
                var country=_IAjaxInterface.GetCountry();
                return Json(country,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult GetState(int id)
        {
            try
            {
                var state=_IAjaxInterface.GetState(id);
                return Json(state,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult GetCity(int id)
        {
            try
            {
                var city=_IAjaxInterface.GetCity(id);
                return Json(city,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}