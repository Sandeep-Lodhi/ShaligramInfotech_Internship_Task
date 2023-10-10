﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace School_Management.Models.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Ram_School_Management_352Entities : DbContext
    {
        public Ram_School_Management_352Entities()
            : base("name=Ram_School_Management_352Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<User> User { get; set; }
    
        public virtual ObjectResult<CityList_Result> CityList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CityList_Result>("CityList");
        }
    
        public virtual int sp_cityadd_edit(Nullable<int> cityId, string cityName, Nullable<int> stateId, Nullable<int> countryId)
        {
            var cityIdParameter = cityId.HasValue ?
                new ObjectParameter("CityId", cityId) :
                new ObjectParameter("CityId", typeof(int));
    
            var cityNameParameter = cityName != null ?
                new ObjectParameter("CityName", cityName) :
                new ObjectParameter("CityName", typeof(string));
    
            var stateIdParameter = stateId.HasValue ?
                new ObjectParameter("StateId", stateId) :
                new ObjectParameter("StateId", typeof(int));
    
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_cityadd_edit", cityIdParameter, cityNameParameter, stateIdParameter, countryIdParameter);
        }
    
        public virtual int sp_stateadd_edit(Nullable<int> stateId, string stateName, Nullable<int> countryId)
        {
            var stateIdParameter = stateId.HasValue ?
                new ObjectParameter("StateId", stateId) :
                new ObjectParameter("StateId", typeof(int));
    
            var stateNameParameter = stateName != null ?
                new ObjectParameter("StateName", stateName) :
                new ObjectParameter("StateName", typeof(string));
    
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_stateadd_edit", stateIdParameter, stateNameParameter, countryIdParameter);
        }
    
        public virtual ObjectResult<StateList_Result> StateList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StateList_Result>("StateList");
        }
    }
}
