using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Palindrom.VjuModeli
{
    public class IndeksVjuModel
    {
        public int ID { get; set; }
        public string Korisnik { get; set; }
        public Nullable<System.DateTime> DatumPostavljanja { get; set; }
        public string Naslov { get; set; }
        
        public string NazivKategorije { get; set; }
        public List<Models.KategorijeKomad> NaziviKategorija { get; set; }

    }
}