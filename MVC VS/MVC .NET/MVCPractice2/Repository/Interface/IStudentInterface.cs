using Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IStudentInterface
    {
        int Register(StudentModel student);
        IEnumerable Department();
        IEnumerable Country();
        IEnumerable State(int? id);
        IEnumerable City(int? id);
        IEnumerable GetDetails();
        StudentModel Edit(int id);
    }
}
