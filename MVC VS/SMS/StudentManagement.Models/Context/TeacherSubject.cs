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
    
    public partial class TeacherSubject
    {
        public int TeacherSubjectId { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public Nullable<int> SubjectId { get; set; }
    
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
