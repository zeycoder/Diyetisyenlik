//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diyetisyenlik.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Day
    {
        public int DayId { get; set; }
        public int UserId { get; set; }
        public int DietId { get; set; }
        public int DietMeal { get; set; }
    
        public virtual Diet Diet { get; set; }
        public virtual User User { get; set; }
    }
}