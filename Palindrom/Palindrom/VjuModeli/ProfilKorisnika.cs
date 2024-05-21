using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Palindrom.VjuModeli
{
    public class ProfilKorisnika : DbContext
    {
        //public DbSet<TemeKorisnika> teme { get; set; }
        //public DbSet<PKorisnika> profil { get; set; }

        public string Korisnik { get; set; }
        public string OpisPr { get; set; }
        public string NazivPrSl { get; set; }
        public int ID { get; set; }
        public string Naslov { get; set; }


    }
}