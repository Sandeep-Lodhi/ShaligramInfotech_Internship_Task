using Exam.Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repositories.Interfaces
{
    public interface ExamInterface
    {
        int registerCustomer(CustomerModel customer);
        int loginUser(string email,string pass);
        IEnumerable GetItems();
        IEnumerable GetCoupen();
        int PlaceOrder(OrderModel order);
        IEnumerable GetOrderByID(int id);
        IEnumerable GetOrderByDate(int id, DateTime? from, DateTime? to);
    }
}
