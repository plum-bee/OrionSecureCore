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
    
    public partial class OrdersDetail
    {
        public short idOrderDetail { get; set; }
        public Nullable<short> idOrder { get; set; }
        public Nullable<int> idPlanet { get; set; }
        public Nullable<short> idReference { get; set; }
        public Nullable<short> Quantity { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Planet Planet { get; set; }
        public virtual Reference Reference { get; set; }
    }
}
