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
    
    public partial class EmergencyLightDetails
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Battery { get; set; }
        public int Bulb { get; set; }
        public int Usable { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public int EmergencyLightHeaderId { get; set; }
        public string InspectedBy { get; set; }
        public string NotedBy { get; set; }
        public string ReviewedBy { get; set; }
        public string ImageUrl { get; set; }
        public int LocationEmergencyLightId { get; set; }
    
        public virtual EmergencyLightHeaders EmergencyLightHeaders { get; set; }
        public virtual Items Items { get; set; }
        public virtual LocationEmergencyLights LocationEmergencyLights { get; set; }
    }
}
