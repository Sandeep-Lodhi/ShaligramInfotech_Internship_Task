//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagement.Models.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class StandardSubject
    {
        public int StandardSubjectId { get; set; }
        public Nullable<int> StandardId { get; set; }
        public Nullable<int> SubjectId { get; set; }
    
        public virtual Standard Standard { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
