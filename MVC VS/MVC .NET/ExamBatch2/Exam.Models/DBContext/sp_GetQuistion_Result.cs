//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exam.Models.DBContext
{
    using System;
    
    public partial class sp_GetQuistion_Result
    {
        public Nullable<int> QuestionId { get; set; }
        public string Qustion { get; set; }
        public int OptionId { get; set; }
        public string Options { get; set; }
        public Nullable<bool> isCorrect { get; set; }
    }
}
