//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDIProcessor
{
    using System;
    using System.Collections.Generic;
    
    public partial class Planet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Planet()
        {
            this.OrdersDetails = new HashSet<OrdersDetail>();
        }
    
        public int idPlanet { get; set; }
        public string CodePlanet { get; set; }
        public string DescPlanet { get; set; }
        public Nullable<int> idSector { get; set; }
        public string @long { get; set; }
        public string lat { get; set; }
        public string parsecs { get; set; }
        public Nullable<int> idNatives { get; set; }
        public Nullable<int> idFiliation { get; set; }
        public string PlanetPicture { get; set; }
        public string IPPlanet { get; set; }
        public string PortPlanet { get; set; }
        public string PortPlanet1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
