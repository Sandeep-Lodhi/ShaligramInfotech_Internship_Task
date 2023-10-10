using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjayTest.Model.Model
{
    public class ResultModel
    {
        public int TotalQuestion { get; set; }
        public int Attempt { get; set; }
        public int Skip { get; set; }
        public int RightAnswer { get; set; }
        public int WrongAnswer { get; set; }
        public string result { get; set; }
    }
}
