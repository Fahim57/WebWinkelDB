//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinkelServiceLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbAankoopRegel
    {
        public int Id { get; set; }
        public int aantal { get; set; }
        public int AankoopId { get; set; }
        public int Product_Id { get; set; }
    
        public virtual tbAankoop Aankopen { get; set; }
        public virtual tbProduct Producten { get; set; }
    }
}