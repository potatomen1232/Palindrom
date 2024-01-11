using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Palindrom.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new Palindrom.Models.Baza1Entities();



            return View(db.PalindromBaza.ToList());
        }

        [HttpPost]
        public ActionResult Index(string tb1) {

            var db = new Palindrom.Models.Baza1Entities();

            List<Models.PalindromBaza> rez = db.PalindromBaza.Where(m => m.Naslov.Contains(tb1)).ToList();
            

            return View(rez);
        }






        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(int id)
        {
            var db = new Palindrom.Models.Baza1Entities();

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
            var db = new Palindrom.Models.Baza1Entities();


           
           

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

    }


}