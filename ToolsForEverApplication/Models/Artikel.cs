//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToolsForEverApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Artikel
    {
        public int Productcode { get; set; }
        public string Product { get; set; }
        public string PType { get; set; }
        public int Fabriekscode { get; set; }
        public double Inkoopprijs { get; set; }
        public double Verkoopprijs { get; set; }
    
        public virtual Fabriek Fabriek { get; set; }
        public virtual Voorraad Voorraad { get; set; }
    }
}
