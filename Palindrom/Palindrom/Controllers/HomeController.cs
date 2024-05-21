using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Dynamic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Palindrom.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Xml;


namespace Palindrom.Controllers
{
   
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            var PalBaza = new Palindrom.Models.Baza1Entities4().PalindromBaza;
            var KatBaza = new Palindrom.Models.Baza1Entities4().Kategorije;

            List<VjuModeli.IndeksVjuModel> IndeksVjuModel = new List<VjuModeli.IndeksVjuModel>();

            var teme = PalBaza.Select(m=> new Models.TemeKomad {ID=m.ID,Naslov=m.Naslov,DatumPostavljanja=m.DatumPostavljanja});

            var kategorije= KatBaza.Select(m=> new Models.KategorijeKomad {NazivKategorije=m.NazivKategorije});

            //IndeksVjuModel.Add(new VjuModeli.IndeksVjuModel { ID =0, DatumPostavljanja = DateTime.Now, Naslov ="Naslov",NazivKategorije=kategorije.ToList() });
            foreach (var red in teme) {

                
                IndeksVjuModel.Add(new VjuModeli.IndeksVjuModel {ID=red.ID,DatumPostavljanja=red.DatumPostavljanja,Naslov=red.Naslov});
            
            }

           


            return View(IndeksVjuModel);
        }

        [HttpPost]
        public ActionResult Index(string tb1) {

            var Baza = new Palindrom.Models.Baza1Entities4();
            var KatBaza = new Palindrom.Models.Baza1Entities4().Kategorije;

            List<Models.PalindromBaza> rez = Baza.PalindromBaza.Where(m => m.Naslov.Contains(tb1)).ToList();

            var kategorijeSpisak = KatBaza.Select(m=> new KategorijeKomad {NazivKategorije=m.NazivKategorije});

            List<VjuModeli.IndeksVjuModel> Ivm = new List<VjuModeli.IndeksVjuModel>();
            Ivm.Add(new VjuModeli.IndeksVjuModel { ID = 1, DatumPostavljanja = DateTime.Now, Korisnik ="kor", Naslov = "nasl", NazivKategorije = "kat", NaziviKategorija = kategorijeSpisak.ToList() });
            foreach (var red in rez) {

                Ivm.Add(new VjuModeli.IndeksVjuModel { ID = red.ID, DatumPostavljanja = red.DatumPostavljanja, Korisnik = red.Korisnik, Naslov = red.Naslov, NazivKategorije = red.Kategorija, NaziviKategorija = kategorijeSpisak.ToList() });
            
            }

            return View(rez);
        }






        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult UcitajTemu(int id)
        {
            var db = new Palindrom.Models.Baza1Entities4();

            var red = db.PalindromBaza.Find(id);



            return View(red);
        }

        [Authorize(Roles ="admin,urednik")]
        public ActionResult DodajSadrzaj() {




            return View();
        }

        [HttpPost]
        public ActionResult DodajSadrzaj(Palindrom.Models.PalindromBaza red)
        {
            var db = new Palindrom.Models.Baza1Entities4();


           
           

            red.DatumIzmene = null;
            red.IzvodjacIzmene = null;
            red.DatumPostavljanja = DateTime.Today;
            red.Korisnik = User.Identity.Name.ToString();
            //red.Tekst = null;
            //red.Naslov = null;

            db.PalindromBaza.Add(red);
                db.SaveChanges();

          

            return RedirectToAction("Index");
        }


         public ActionResult MojeTeme() {

          
            var db = new Palindrom.Models.Baza1Entities4();
            var db1 = new Palindrom.Models.Entities();

            var db3 = new Palindrom.VjuModeli.TemeKorisnika();

            

            //var naslovi = db.PalindromBaza.Select(m => new Palindrom.VjuModeli.TemeKorisnika{Korisnik = m.Korisnik, ID= m.ID, Naslov=m.Naslov });

            var naslovi = db.PalindromBaza.Where(m => m.Korisnik == User.Identity.Name);
           
            var ajdijevi = db.PalindromBaza.Where(m => m.Korisnik == User.Identity.Name);

            var profil = db1.AspNetUsers.Select(m => new Palindrom.VjuModeli.PKorisnika {OpisPr = m.OpisProfila,NazivPrSl=m.NazivProfilneSlike ,Korisnik = m.UserName});

            List<Palindrom.VjuModeli.VjuModZaProfil> profilov = new List<Palindrom.VjuModeli.VjuModZaProfil>();
            int i = -1;

            try { 
                ajdijevi.First(); 
                foreach (var red in naslovi)
                {
                    i++;
                    profilov.Add(new VjuModeli.VjuModZaProfil
                    {
                        ID = Convert.ToInt32(ajdijevi.ToArray()[i].ID),
                        Korisnik = profil.First(m => m.Korisnik == User.Identity.Name).Korisnik.ToString(),
                        Naslov = naslovi.ToArray()[i].Naslov.ToString(),
                        OpisPr = profil.FirstOrDefault(m => m.Korisnik == User.Identity.Name).OpisPr.ToString(),
                        NazivPrSl = "img.png"                
                    }
                   );
                }
            }

            catch { 
                profilov.Add(new VjuModeli.VjuModZaProfil
                {
                    Naslov = "nslv",
                    ID = 0,
                    Korisnik = profil.First(m => m.Korisnik == User.Identity.Name).Korisnik.ToString(),
                    OpisPr = profil.FirstOrDefault(m => m.Korisnik == User.Identity.Name).OpisPr.ToString(),
                    NazivPrSl = "img.png"
                }
                );
            }
            return View(profilov);
        }


        public ActionResult IzmeniSadrzaj(int id) {








            return View();
        }

        public PartialViewResult ProfilDelimicni() {


            var db1 = new Palindrom.Models.Entities();

            //var red = db.AspNetUsers.Where(m => m.UserName == User.Identity.Name);

            var db2 = new Palindrom.VjuModeli.ProfilKorisnika();






            return PartialView();
        }

        public ActionResult SpisakTemaPoKat(string kat) {

            var db = new Palindrom.Models.Baza1Entities4();

            List<PalindromBaza> rezultati = db.PalindromBaza.Where(m => m.Kategorija.ToString() == kat).ToList();

            if (rezultati.Count() == 0) { rezultati.Add(new PalindromBaza { ID = 0, Kategorija = kat }); }


            return View(rezultati.ToList());

            
        }
    }


}