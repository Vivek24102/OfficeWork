//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class treatmentdetail
    {
        public int id { get; set; }
        public Nullable<int> patientid { get; set; }
        public Nullable<int> doctorid { get; set; }
        public Nullable<int> Nurseid { get; set; }
        public Nullable<int> diagnosis { get; set; }
        public Nullable<int> prescription { get; set; }
        public decimal treatmentfee { get; set; }
        public Nullable<System.DateTime> dot { get; set; }
        public string instruction { get; set; }
    
        public virtual diagnosi diagnosi { get; set; }
        public virtual medicine medicine { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual UserType UserType1 { get; set; }
        public virtual UserType UserType2 { get; set; }
    }
}