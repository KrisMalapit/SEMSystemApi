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
    
    public partial class FireExtinguisherDetail
    {
        public int Id { get; set; }
        public int LocationFireExtinguisherId { get; set; }
        public int Cylinder { get; set; }
        public int Lever { get; set; }
        public int Gauge { get; set; }
        public int SafetySeal { get; set; }
        public int Hose { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public int FireExtinguisherHeaderId { get; set; }
        public string InspectedBy { get; set; }
        public string NotedBy { get; set; }
        public string ReviewedBy { get; set; }
    
        public virtual FireExtinguisherHeader FireExtinguisherHeader { get; set; }
    }
}