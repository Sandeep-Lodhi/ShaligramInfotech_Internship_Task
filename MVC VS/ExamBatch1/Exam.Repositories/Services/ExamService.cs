using Exam.Helpers.Helpers;
using Exam.Models.DBContext;
using Exam.Models.Models;
using Exam.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repositories.Services
{
    public class ExamService:ExamInterface
    {
        KrunalDhote351Entities _Db = new KrunalDhote351Entities();
        public int registerCustomer(CustomerModel customer)
        {
            var result = ExamHelper.RegisterCustomer(customer);
            if (result != null)
            {
                _Db.CustomerMaster.Add(result);
                _Db.SaveChanges();
                return result.CustId;
            }
            return 0;
        }
        public int loginUser(string email,string pass)
        {
            var result = _Db.CustomerMaster.Where(x => x.Email == email && x.Password == pass).FirstOrDefault();
            if (result!=null)
            {
                return result.CustId;
            }
            return 0;
        }

        public IEnumerable GetItems()
        {
            var result = _Db.ItemMaster.ToList();
            return result;
        }
        public IEnumerable GetCoupen()
        {
            var result = _Db.CoupenCodeMaster.ToList();
            return result;
        }
        public int PlaceOrder(OrderModel order)
        {
            var result = ExamHelper.PlaceOrder(order);
            if (result != null)
            {
                _Db.OrdersMaster.Add(result);
                _Db.SaveChanges();
                return result.OrderId;
            }
            return 0;
        }
        public IEnumerable GetOrderByID(int id)
        {
            var result = _Db.OrdersMaster.Where(x => x.CustId == id).ToList();
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public IEnumerable GetOrderByDate(int id,DateTime? from,DateTime? to)
        {
            var result = _Db.sp_GetOrdersByDate(id,from,to).ToList();
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
