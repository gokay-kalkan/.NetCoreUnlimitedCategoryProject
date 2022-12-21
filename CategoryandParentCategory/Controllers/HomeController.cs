using CategoryandParentCategory.Context;
using CategoryandParentCategory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static CategoryandParentCategory.Models.AltKategorilerModel;

namespace CategoryandParentCategory.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();

        public IActionResult Index()
        {
            //var kategoriler = db.Kategoriler.ToList();

            //var altKategoriler = new List<AltKategori>();

            //foreach (var altkategori in kategoriler.OrderBy(x=>x.Id))
            //{
            //    if (altkategori.UstKategoriId == null)
            //    {
            //        altKategoriler.Add(new AltKategori
            //        {
            //            Id = altkategori.Id,
            //            Ad = altkategori.Ad,
            //            Aciklama=altkategori.Aciklama,
            //            UstKategoriId = altkategori.UstKategoriId
            //        });
            //    }
            //    if (altkategori.UstKategoriId != null)
            //    {
            //        altKategoriler.Add(new AltKategori
            //        {
            //            Id = altkategori.Id,
            //            Ad = altkategori.Ad,
            //            Aciklama = altkategori.Aciklama,
            //            UstKategoriId = altkategori.UstKategoriId
            //        });
            //    }
            //}
            //ViewBag.kategoriler = kategoriler.Where(x=>x.UstKategoriId==null).ToList();


            //var model = new AltKategorilerModel { AltKategoriler = altKategoriler };


            // var kategoriler = db.Kategoriler.ToList();


            // var anaKategoriler = kategoriler.Where(x => x.UstKategoriId == null).ToList();

            // Alt kategorileri listele

            //var altKategoriler = kategoriler.Where(x => x.UstKategoriId != null).ToList();

            // var model = new AltKategorilerinModel
            // {
            //     AnaKategoriler = anaKategoriler,
            //     AltKategoriler = altKategoriler
            // };

            var model = db.Kategoriler.ToList();
            return View(model);
        }

        public IActionResult Detay(int id)
        {
            var detay = db.Urunler.Include(x=>x.Kategori).Where(x => x.KategoriId == id).FirstOrDefault();
  
            return View(detay);
        }

        public IActionResult Create()
        {
            List<SelectListItem> deger1 = (from i in db.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Kategori data)
        {


            return View();
        }

        public IActionResult Update(int id)
        {
            List<SelectListItem> deger1 = (from i in db.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;

            var kategori = db.Kategoriler.Where(x => x.Id == id).FirstOrDefault();

            return View(kategori);
        }

        [HttpPost]
        public IActionResult Update(Kategori data)
        {

            var kategori = db.Kategoriler.Where(x => x.Id == data.Id).FirstOrDefault();
            kategori.Ad = data.Ad;
            kategori.UstKategoriId = data.UstKategoriId;
            db.Kategoriler.Update(kategori);
            db.SaveChanges();
                
            return RedirectToAction();
        }
    }
}