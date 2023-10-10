﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandeepMVC3_Test.Models.Models
{
    public class StateModel
    {
        public int id { get; set; }
        public string StateName { get; set; }
        public Nullable<int> Cid { get; set; }

        public virtual ICollection<CityModel> City { get; set; }
        public virtual CountryModel Country { get; set; }
    }
}
