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
    
    public partial class BicycleEntryDetail
    {
        public int Id { get; set; }
        public int BicycleEntryHeaderId { get; set; }
        public int FrameSafe { get; set; }
        public int FrameUnSafe { get; set; }
        public string FrameRemarks { get; set; }
        public int FrontForkSafe { get; set; }
        public int FrontForkUnSafe { get; set; }
        public string FrontForkRemarks { get; set; }
        public int HandlebarSafe { get; set; }
        public int HandlebarUnSafe { get; set; }
        public string HandlebarRemarks { get; set; }
        public int SeatSafe { get; set; }
        public int SeatUnSafe { get; set; }
        public string SeatRemarks { get; set; }
        public int FrontRearSafe { get; set; }
        public int FrontRearUnSafe { get; set; }
        public string FrontRearRemarks { get; set; }
        public int BrakeSafe { get; set; }
        public int BrakeUnSafe { get; set; }
        public string BrakeRemarks { get; set; }
        public int CrankChainSafe { get; set; }
        public int CrankChainUnSafe { get; set; }
        public string CrankChainRemarks { get; set; }
        public int ChainSafe { get; set; }
        public int ChainUnSafe { get; set; }
        public string ChainRemarks { get; set; }
        public string InspectedBy { get; set; }
        public string NotedBy { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedAt { get; set; }
    
        public virtual BicycleEntryHeader BicycleEntryHeader { get; set; }
    }
}
