//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkTimer.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Time
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> Time1 { get; set; }
        public int TaskID { get; set; }
    
        public virtual Task Task { get; set; }
    }
}
