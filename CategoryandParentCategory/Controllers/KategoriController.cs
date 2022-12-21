using CategoryandParentCategory.Context;
using CategoryandParentCategory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CategoryandParentCategory.Controllers
{
    public class KategoriController : Controller
    {
        private DataContext db = new DataContext();

        public IActionResult Index()
        {
            var kategoriler = db.Kategoriler.ToList();
       
            return View(kategoriler);
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
            db.Kategoriler.Add(data);
            db.SaveChanges();

            return RedirectToAction("Index");
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
