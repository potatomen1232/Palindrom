//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Palindrom.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PalindromBaza
    {
        public int ID { get; set; }
        public string Korisnik { get; set; }
        public string Tekst { get; set; }
        public Nullable<System.DateTime> DatumPostavljanja { get; set; }
        public Nullable<System.DateTime> DatumIzmene { get; set; }
        public string IzvodjacIzmene { get; set; }
        public string Naslov { get; set; }
        public string Kategorija { get; set; }
    }
}
