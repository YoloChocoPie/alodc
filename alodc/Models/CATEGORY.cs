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
    
    public partial class CATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORY()
        {
            this.FOODs = new HashSet<FOOD>();
        }
    
        public int ID { get; set; }
        public string CATEGORY_CODE { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string IMAGE_URL { get; set; }
        public bool STATUS { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public Nullable<int> AGE { get; set; }
        public Nullable<decimal> PRICE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOOD> FOODs { get; set; }
    }
}
