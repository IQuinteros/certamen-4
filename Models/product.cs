//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IgnacioQuinteros.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ShortSummary { get; set; }
        public bool MaxVisibility { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }

        public string GetMediumClass() => MaxVisibility ? "product-item--medium" : "";
    }
}
