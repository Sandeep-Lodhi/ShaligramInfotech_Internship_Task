//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SandeepMVC_TestPractice.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class City
    {
        public City()
        {
            this.Registration = new HashSet<Registration>();
        }
    
        public int id { get; set; }
        public string CityName { get; set; }
        public Nullable<int> Cid { get; set; }
        public Nullable<int> Sid { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
    }
}