//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrdersManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdersDetail
    {
        public short idOrderDetail { get; set; }
        public Nullable<short> idOrder { get; set; }
        public Nullable<int> idPlanet { get; set; }
        public Nullable<short> idReference { get; set; }
        public Nullable<short> Quantity { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Planets Planets { get; set; }
        public virtual References References { get; set; }
    }
}
