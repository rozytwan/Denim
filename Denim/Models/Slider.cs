//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Denim.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Slider
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

        public IEnumerable<Slider> slidList { get; set; }
    }
}
