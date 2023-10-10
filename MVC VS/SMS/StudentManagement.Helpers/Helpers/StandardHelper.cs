using StudentManagement.Models.Context;
using StudentManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Helpers.Helpers
{
    public class StandardHelper
    {
        public List<StandardModel> ConvertStandardToStandardModelList(List<Standard> standardList)
        {
            List<StandardModel> standardModelList = new List<StandardModel>();

            foreach (Standard standard in standardList)
            {
                standardModelList.Add(
                    new StandardModel()
                    {
                        StandardId = standard.StandardId,
                        StandardName = standard.StandardName
                    }
                    );
            }
            return standardModelList;
        }
    }
}
