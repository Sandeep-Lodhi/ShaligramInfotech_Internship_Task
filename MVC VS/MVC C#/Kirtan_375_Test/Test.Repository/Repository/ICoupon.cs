﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.DbContext;

namespace Test.Repository.Repository
{
    public class ICoupon
    {
        IEnumerable<CouponCodeMaster> GetCoupons { get; }
    }
}
