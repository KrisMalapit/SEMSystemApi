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
    
    public partial class LocationInergenTanks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LocationInergenTanks()
        {
            this.InergenTankDetails = new HashSet<InergenTankDetails>();
        }
    
        public int Id { get; set; }
        public string Location { get; set; }
        public string Area { get; set; }
        public int AreaId { get; set; }
        public string Status { get; set; }
    
        public virtual Areas Areas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InergenTankDetails> InergenTankDetails { get; set; }
    }
}
