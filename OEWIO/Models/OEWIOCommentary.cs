//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OEWIO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OEWIOCommentary
    {
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> ProductID { get; set; }
        public string Comment { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Modified { get; set; }
    
        public virtual OEWIOProduct OEWIOProduct { get; set; }
    }
}
