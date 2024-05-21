using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Palindrom.Models
{
    public class TemeKomad
    {
        public int ID { get; set; }
        public string Korisnik { get; set; }
        public Nullable<System.DateTime> DatumPostavljanja { get; set; }
        public string Naslov { get; set; }
    }
}