//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace alodc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MENU()
        {
            this.ORDER_DETAIL = new HashSet<ORDER_DETAIL>();
        }
    
        public int ID { get; set; }
        public int FOOD_ID { get; set; }
        public int ACCOUNT_ID { get; set; }
        public System.DateTime DATE { get; set; }
        public int QUANTITY { get; set; }
        public int PRICE { get; set; }
        public bool STATUS { get; set; }
    
        public virtual ACCOUNT ACCOUNT { get; set; }
        public virtual FOOD FOOD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAIL> ORDER_DETAIL { get; set; }
    }
}
