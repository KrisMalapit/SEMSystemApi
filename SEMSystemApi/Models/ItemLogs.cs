//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEMSystemApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemLogs
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public string Module { get; set; }
    
        public virtual Items Items { get; set; }
    }
}