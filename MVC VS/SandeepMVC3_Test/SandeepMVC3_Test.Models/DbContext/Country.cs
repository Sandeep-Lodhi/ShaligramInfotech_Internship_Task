//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SandeepMVC3_Test.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Country
    {
        public Country()
        {
            this.City = new HashSet<City>();
            this.Registration = new HashSet<Registration>();
            this.State = new HashSet<State>();
        }
    
        public int id { get; set; }
        public string CountryName { get; set; }
    
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}
