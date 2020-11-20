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
    
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            this.NOTIFICATIONs = new HashSet<NOTIFICATION>();
            this.ORDER_DETAIL = new HashSet<ORDER_DETAIL>();
        }
    
        public int ID { get; set; }
        public string ORDER_CODE { get; set; }
        public System.DateTime DATE { get; set; }
        public Nullable<int> ACCOUNT_ID { get; set; }
        public int CUSTOMER_ID { get; set; }
        public int STATUS { get; set; }
        public string FEEDBACK { get; set; }
    
        public virtual ACCOUNT ACCOUNT { get; set; }
        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTIFICATION> NOTIFICATIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAIL> ORDER_DETAIL { get; set; }
    }
}