//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sandeep_QuizApp_Practice.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Answer
    {
        public int id { get; set; }
        public Nullable<int> questionId { get; set; }
        public string title { get; set; }
        public Nullable<bool> isactive { get; set; }
        public Nullable<bool> isCorrect { get; set; }
    
        public virtual Question Question { get; set; }
    }
}
